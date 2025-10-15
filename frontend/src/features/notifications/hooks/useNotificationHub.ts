import { useEffect } from 'react';
import { notificationHub } from '../services/notification-hub';
import { useNotificationStore } from '../store/notification-store';

export const useNotificationHub = () => {
  const { addNotification, fetchStats } = useNotificationStore();

  useEffect(() => {
    const startHub = async () => {
      try {
        await notificationHub.start();

        // Subscribe to incoming notifications
        const unsubscribe = notificationHub.subscribe(notification => {
          addNotification(notification);
          fetchStats();
        });

        return unsubscribe;
      } catch (error) {
        console.error('Failed to start notification hub:', error);
      }
    };

    const unsubscribePromise = startHub();

    return () => {
      unsubscribePromise.then(unsubscribe => {
        if (unsubscribe) unsubscribe();
        notificationHub.stop();
      });
    };
  }, [addNotification, fetchStats]);

  return {
    connectionState: notificationHub.getConnectionState(),
  };
};
