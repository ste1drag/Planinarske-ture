import { NOTIFICATION_ENDPOINTS } from './notification-endpoints';
import {
  InAppNotificationResponse,
  NotificationFilters,
  NotificationStats,
} from '../types';
import { axios_instance } from '@/lib/root-api';

export const getNotifications = async (
  filters?: NotificationFilters
): Promise<InAppNotificationResponse[]> => {
  const response = await axios_instance.get<InAppNotificationResponse[]>(
    NOTIFICATION_ENDPOINTS.GET_NOTIFICATIONS,
    { params: filters }
  );
  return response.data;
};

export const getNotificationById = async (
  id: string
): Promise<InAppNotificationResponse> => {
  const response = await axios_instance.get<InAppNotificationResponse>(
    NOTIFICATION_ENDPOINTS.GET_NOTIFICATION_BY_ID(id)
  );
  return response.data;
};

export const markAsRead = async (id: string): Promise<void> => {
  await axios_instance.patch(NOTIFICATION_ENDPOINTS.MARK_AS_READ(id));
};

export const markAllAsRead = async (): Promise<void> => {
  await axios_instance.patch(NOTIFICATION_ENDPOINTS.MARK_ALL_AS_READ);
};

export const deleteNotification = async (id: string): Promise<void> => {
  await axios_instance.delete(NOTIFICATION_ENDPOINTS.DELETE_NOTIFICATION(id));
};

export const getNotificationStats = async (): Promise<NotificationStats> => {
  const response = await axios_instance.get<NotificationStats>(
    NOTIFICATION_ENDPOINTS.GET_STATS
  );
  return response.data;
};
