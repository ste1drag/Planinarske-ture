const IDENTITY_API_BASE_URL = '/identity-api';

export const AUTH_ENDPOINTS = {
  LOGIN: `${IDENTITY_API_BASE_URL}/Authentication/Login`,
  REGISTER_USER: `${IDENTITY_API_BASE_URL}/Authentication/RegisterUser`,
  REGISTER_ADMIN: `${IDENTITY_API_BASE_URL}/Authentication/RegisterAdministrator`,
  REFRESH_TOKEN: `${IDENTITY_API_BASE_URL}/Authentication/Refresh`,
  LOGOUT: `${IDENTITY_API_BASE_URL}/Authentication/Logout`,
  GET_ALL_USERS: `${IDENTITY_API_BASE_URL}/User`,
  ASSIGN_TOUR_GUIDE: (userId: string) =>
    `${IDENTITY_API_BASE_URL}/User/${userId}/assign-tour-guide`,
} as const;
