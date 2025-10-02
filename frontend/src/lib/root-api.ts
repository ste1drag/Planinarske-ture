import axios from 'axios';

const API_BASE_URL = '';

export const axios_instance = axios.create({ baseURL: API_BASE_URL });

axios_instance.interceptors.request.use(
  config => {
    const token = localStorage.getItem('auth_token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
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
    return response;
  },
  error => {
    if (error.response?.status === 401) {
      localStorage.removeItem('auth_token');
      console.warn('Authentication failed - token cleared');
    }
    return Promise.reject(error);
  }
);
