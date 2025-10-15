import { formatDistanceToNow } from 'date-fns';
import { InAppNotificationResponse } from '../types';

interface NotificationItemProps {
  notification: InAppNotificationResponse;
}

export const NotificationItem = ({ notification }: NotificationItemProps) => {
  return (
    <div
      className={`p-4 transition-colors relative ${
        notification.status === 'Unread' ? 'bg-blue-50' : ''
      }`}
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
            {notification.content}
          </p>
          <span className="text-xs text-gray-400 mt-1 block">
            {formatDistanceToNow(new Date(notification.createdAt || notification.occuredOn), {
              addSuffix: true,
            })}
          </span>
        </div>
      </div>
    </div>
  );
};
