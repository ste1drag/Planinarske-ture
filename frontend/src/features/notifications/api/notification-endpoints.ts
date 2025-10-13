export const NOTIFICATION_ENDPOINTS = {
  GET_NOTIFICATIONS: '/api/notifications',
  GET_NOTIFICATION_BY_ID: (id: string) => `/api/notifications/${id}`,
  MARK_AS_READ: (id: string) => `/api/notifications/${id}/read`,
  MARK_ALL_AS_READ: '/api/notifications/read-all',
  DELETE_NOTIFICATION: (id: string) => `/api/notifications/${id}`,
  GET_STATS: '/api/notifications/stats',
};
