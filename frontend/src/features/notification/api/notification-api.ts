import { NOTIFICATION_ENDPOINTS } from './notification-endpoints';
import { Notification } from '../types/notification';
import { axios_instance } from '@/lib/root-api';

export const getAllNotifications = async (): Promise<Notification[]> => {
  const response = await axios_instance.get<Notification[]>(
    NOTIFICATION_ENDPOINTS.GET_ALL_NOTIFICATIONS
  );
  return response.data;
};

export const getNotificationById = async (
  id: string
): Promise<Notification> => {
  const response = await axios_instance.get<Notification>(
    NOTIFICATION_ENDPOINTS.GET_NOTIFICATION_BY_ID(id)
  );
  return response.data;
};

export const markNotificationAsRead = async (id: string): Promise<void> => {
  await axios_instance.patch(NOTIFICATION_ENDPOINTS.MARK_AS_READ(id));
};
