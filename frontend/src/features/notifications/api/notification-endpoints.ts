const NOTIFICATION_API_BASE_URL = '/notification-api';

export const NOTIFICATION_ENDPOINTS = {
  GET_NOTIFICATIONS: `${NOTIFICATION_API_BASE_URL}/api/InAppNotifications`,
  GET_NOTIFICATION_BY_ID: (id: string) => `${NOTIFICATION_API_BASE_URL}/api/InAppNotifications/${id}`,
  MARK_AS_READ: (id: string) => `${NOTIFICATION_API_BASE_URL}/api/InAppNotifications/${id}`,
  MARK_ALL_AS_READ: `${NOTIFICATION_API_BASE_URL}/api/InAppNotifications`,
  DELETE_NOTIFICATION: (id: string) => `${NOTIFICATION_API_BASE_URL}/api/InAppNotifications/${id}`,
  GET_STATS: `${NOTIFICATION_API_BASE_URL}/api/InAppNotifications`,
};
