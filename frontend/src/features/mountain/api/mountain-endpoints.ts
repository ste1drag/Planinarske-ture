const TOURS_API_BASE_URL = 'http://localhost:8080';

export const MOUNTAINS_ENDPOINTS = {
  GET_ALL_MOUNTAINS: `${TOURS_API_BASE_URL}/api/Mountains`,
} as const;
