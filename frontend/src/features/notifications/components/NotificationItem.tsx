import { formatDistanceToNow } from 'date-fns';
import { X } from 'lucide-react';
import { useNotificationStore } from '../store/notification-store';
import { InAppNotificationResponse } from '../types';
import { Button } from '@/components/ui/Button';

interface NotificationItemProps {
  notification: InAppNotificationResponse;
}

export const NotificationItem = ({ notification }: NotificationItemProps) => {
  const { markNotificationAsRead, deleteNotification } = useNotificationStore();

  const handleClick = async () => {
    if (notification.status === 'Unread') {
      await markNotificationAsRead(notification.id);
    }

    // Navigate to related entity if applicable
    if (notification.relatedEntityId && notification.relatedEntityType) {
      // TODO: Add navigation logic based on entity type
      console.log(
        'Navigate to:',
        notification.relatedEntityType,
        notification.relatedEntityId
      );
    }
  };

  const handleDelete = async (e: React.MouseEvent) => {
    e.stopPropagation();
    await deleteNotification(notification.id);
  };

  return (
    <div
      className={`p-4 hover:bg-gray-50 cursor-pointer transition-colors relative group ${
        notification.status === 'Unread' ? 'bg-blue-50' : ''
      }`}
      onClick={handleClick}
    >
      <div className="flex items-start justify-between gap-2">
        <div className="flex-1 min-w-0">
          <div className="flex items-center gap-2">
            <h4 className="font-medium text-sm truncate">
              {notification.title}
            </h4>
            {notification.status === 'Unread' && (
              <span className="h-2 w-2 rounded-full bg-blue-500 flex-shrink-0" />
            )}
          </div>
          <p className="text-sm text-gray-600 mt-1 line-clamp-2">
            {notification.message}
          </p>
          <span className="text-xs text-gray-400 mt-1 block">
            {formatDistanceToNow(new Date(notification.createdAt), {
              addSuffix: true,
            })}
          </span>
        </div>
        <Button
          variant="ghost"
          size="icon"
          className="opacity-0 group-hover:opacity-100 transition-opacity h-6 w-6"
          onClick={handleDelete}
        >
          <X className="h-4 w-4" />
        </Button>
      </div>
    </div>
  );
};
