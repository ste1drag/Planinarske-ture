import { Bell } from 'lucide-react';
import { Notification } from '../types/notification';

interface NotificationCardProps {
  notification: Notification;
}

const NotificationCard = ({ notification }: NotificationCardProps) => {
  return (
    <div className="bg-white dark:bg-gray-800 rounded-lg shadow-md border border-gray-200 dark:border-gray-700 p-4 hover:shadow-lg transition-shadow">
      <div className="flex items-start gap-3">
        <div className="flex-shrink-0 mt-1">
          <div className="w-10 h-10 bg-blue-100 dark:bg-blue-900 rounded-full flex items-center justify-center">
            <Bell className="w-5 h-5 text-blue-600 dark:text-blue-300" />
          </div>
        </div>
        <div className="flex-1 min-w-0">
          <h3 className="text-lg font-semibold text-gray-900 dark:text-white mb-1">
            {notification.title}
          </h3>
          {notification.description && (
            <p className="text-sm text-gray-600 dark:text-gray-400 mb-2">
              {notification.description}
            </p>
          )}
          {notification.content && (
            <div className="mt-2 text-sm text-gray-700 dark:text-gray-300 whitespace-pre-line">
              {notification.content}
            </div>
          )}
          <p className="text-xs text-gray-500 dark:text-gray-500 mt-3">
            {new Date(notification.timestamp).toLocaleString()}
          </p>
        </div>
      </div>
    </div>
  );
};

export default NotificationCard;
