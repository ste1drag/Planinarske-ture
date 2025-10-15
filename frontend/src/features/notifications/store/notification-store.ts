import { create } from 'zustand';
import {
  getNotifications,
  markAsRead,
  markAllAsRead,
  deleteNotification,
  getNotificationStats,
} from '../api/notification-api';
import {
  InAppNotificationResponse,
  NotificationFilters,
  NotificationStats,
  NotificationStatus,
} from '../types';

interface NotificationStore {
  notifications: InAppNotificationResponse[];
  stats: NotificationStats | null;
  isLoading: boolean;
  error: string | null;

  // Actions
  fetchNotifications: (filters?: NotificationFilters) => Promise<void>;
  fetchStats: () => Promise<void>;
  markNotificationAsRead: (id: string) => Promise<void>;
  markAllNotificationsAsRead: () => Promise<void>;
  deleteNotification: (id: string) => Promise<void>;
  addNotification: (notification: InAppNotificationResponse) => void;
  clearError: () => void;
  clearNotifications: () => void;
}

export const useNotificationStore = create<NotificationStore>((set, get) => ({
  notifications: [],
  stats: null,
  isLoading: false,
  error: null,

  fetchNotifications: async (filters?: NotificationFilters) => {
    set({ isLoading: true, error: null });
    try {
      const notifications = await getNotifications(filters);
      set({ notifications, isLoading: false });
    } catch (error) {
      const errorMessage =
        (error as any)?.response?.data?.message ||
        'Failed to fetch notifications';
      set({ error: errorMessage, isLoading: false });
    }
  },

  fetchStats: async () => {
    try {
      const stats = await getNotificationStats();
      set({ stats });
    } catch (error) {
      console.error('Failed to fetch notification stats:', error);
    }
  },

  markNotificationAsRead: async (id: string) => {
    try {
      await markAsRead(id);

      const { notifications, stats } = get();
      const updatedNotifications = notifications.map(notification =>
        notification.id === id
          ? {
              ...notification,
              status: NotificationStatus.Read,
              readAt: new Date().toISOString(),
            }
          : notification
      );

      const updatedStats = stats
        ? { ...stats, unreadCount: Math.max(0, stats.unreadCount - 1) }
        : null;

      set({ notifications: updatedNotifications, stats: updatedStats });
    } catch (error) {
      const errorMessage =
        (error as any)?.response?.data?.message ||
        'Failed to mark notification as read';
      set({ error: errorMessage });
    }
  },

  markAllNotificationsAsRead: async () => {
    try {
      await markAllAsRead();

      const { notifications } = get();
      const updatedNotifications = notifications.map(notification => ({
        ...notification,
        status: NotificationStatus.Read,
        readAt: notification.readAt ?? new Date().toISOString(),
      }));

      set({
        notifications: updatedNotifications,
        stats: { unreadCount: 0, totalCount: updatedNotifications.length },
      });
    } catch (error) {
      const errorMessage =
        (error as any)?.response?.data?.message ||
        'Failed to mark all notifications as read';
      set({ error: errorMessage });
    }
  },

  deleteNotification: async (id: string) => {
    try {
      await deleteNotification(id);

      const { notifications, stats } = get();
      const notificationToDelete = notifications.find(n => n.id === id);
      const updatedNotifications = notifications.filter(n => n.id !== id);

      const updatedStats = stats
        ? {
            ...stats,
            totalCount: stats.totalCount - 1,
            unreadCount:
              notificationToDelete?.status === 'Unread'
                ? Math.max(0, stats.unreadCount - 1)
                : stats.unreadCount,
          }
        : null;

      set({ notifications: updatedNotifications, stats: updatedStats });
    } catch (error) {
      const errorMessage =
        (error as any)?.response?.data?.message ||
        'Failed to delete notification';
      set({ error: errorMessage });
    }
  },

  addNotification: (notification: InAppNotificationResponse) => {
    const { notifications, stats } = get();
    set({
      notifications: [notification, ...notifications],
      stats: stats
        ? {
            ...stats,
            totalCount: stats.totalCount + 1,
            unreadCount: stats.unreadCount + 1,
          }
        : { totalCount: 1, unreadCount: 1 },
    });
  },

  clearError: () => set({ error: null }),

  clearNotifications: () => set({ notifications: [], stats: null }),
}));
