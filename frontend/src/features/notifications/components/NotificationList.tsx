import { useEffect } from 'react';
import { NotificationItem } from './NotificationItem';
import { useNotificationStore } from '../store/notification-store';
import { ScrollArea } from '@/components/ui/scroll-area';

export const NotificationList = () => {
  const {
    notifications,
    isLoading,
    error,
    fetchNotifications,
  } = useNotificationStore();

  useEffect(() => {
    fetchNotifications();
  }, [fetchNotifications]);

  if (isLoading) {
    return (
      <div className="p-4 text-center text-sm text-gray-500">
        Loading notifications...
      </div>
    );
  }

  if (error) {
    return <div className="p-4 text-center text-sm text-red-500">{error}</div>;
  }

  if (notifications.length === 0) {
    return (
      <div className="p-4 text-center text-sm text-gray-500">
        No notifications
      </div>
    );
  }

  return (
    <div className="flex flex-col">
      <div className="flex items-center justify-between p-4 border-b">
        <h3 className="font-semibold">Notifications</h3>
      </div>
      <ScrollArea className="h-[400px]">
        <div className="divide-y">
          {notifications.map(notification => (
            <NotificationItem
              key={notification.id}
              notification={notification}
            />
          ))}
        </div>
      </ScrollArea>
    </div>
  );
};
