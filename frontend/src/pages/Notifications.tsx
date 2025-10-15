import { Loader2 } from 'lucide-react';
import { useEffect } from 'react';
import { useNotificationStore } from '@/features/notifications/store/notification-store';
import { NotificationItem } from '@/features/notifications/components/NotificationItem';

const Notifications = () => {
  const {
    notifications,
    isLoading,
    error,
    fetchNotifications,
  } = useNotificationStore();

  useEffect(() => {
    fetchNotifications();
  }, [fetchNotifications]);

  // Debug logging
  console.log('Notifications Page:', {
    notifications,
    isLoading,
    error,
    count: notifications?.length
  });

  if (isLoading) {
    return (
      <div className="container mx-auto px-4 py-8 flex justify-center items-center min-h-[50vh]">
        <Loader2 className="w-8 h-8 animate-spin text-forest" />
      </div>
    );
  }

  if (error) {
    return (
      <div className="container mx-auto px-4 py-8">
        <h1 className="text-3xl font-bold mb-6">Notifications</h1>
        <div className="bg-red-50 dark:bg-red-900/20 border border-red-200 dark:border-red-800 rounded-lg p-4 text-red-700 dark:text-red-400">
          {error}
        </div>
      </div>
    );
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <h1 className="text-3xl font-bold mb-6">Notifications</h1>
      {notifications.length === 0 ? (
        <div className="text-center py-12">
          <p className="text-gray-500 dark:text-gray-400 text-lg">
            No notifications yet. You&apos;ll see them here when you receive new
            notifications.
          </p>
        </div>
      ) : (
        <div className="space-y-4">
          {notifications.map(notification => (
            <NotificationItem
              key={notification.id}
              notification={notification}
            />
          ))}
        </div>
      )}
    </div>
  );
};

export default Notifications;
