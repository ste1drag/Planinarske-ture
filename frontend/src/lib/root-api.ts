import axios from 'axios';

const API_BASE_URL = '';

export const axios_instance = axios.create({ baseURL: API_BASE_URL });

axios_instance.interceptors.request.use(
  config => {
    const token = localStorage.getItem('auth_token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    if (process.env.REACT_APP_USE_MOCKS === 'true') {
      console.log(
        `🔄 Mock API Request: ${config.method?.toUpperCase()} ${config.url}`
      );
    }
    return config;
  },
  error => {
    console.error('Request interceptor error:', error);
    return Promise.reject(error);
  }
);

axios_instance.interceptors.response.use(
  response => {
    if (process.env.REACT_APP_USE_MOCKS === 'true') {
      console.log(
        `✅ Mock API Response: ${response.status} ${response.config.url}`
      );
    }

    return response;
  },
  error => {
    if (error.response?.status === 401) {
      localStorage.removeItem('auth_token');
      console.warn('Authentication failed - token cleared');
    }
    if (process.env.REACT_APP_USE_MOCKS === 'true') {
      console.error(
        `❌ Mock API Error: ${error.response?.status} ${error.config?.url}`
      );
    }
    return Promise.reject(error);
  }
);
