const IDENTITY_API_BASE_URL = 'http://localhost:8081';

export const AUTH_ENDPOINTS = {
  LOGIN: `${IDENTITY_API_BASE_URL}/Authentication/Login`,
  REGISTER_USER: `${IDENTITY_API_BASE_URL}/Authentication/RegisterUser`,
  REGISTER_ADMIN: `${IDENTITY_API_BASE_URL}/Authentication/RegisterAdministrator`,
  REFRESH_TOKEN: `${IDENTITY_API_BASE_URL}/Authentication/Refresh`,
  LOGOUT: `${IDENTITY_API_BASE_URL}/Authentication/Logout`,
} as const;
