import { useEffect, useState } from 'react';
import { X, Bell } from 'lucide-react';
import { Notification } from '../types/notification';

interface NotificationPopupProps {
  notification: Notification;
  onClose: () => void;
}

const NotificationPopup = ({
  notification,
  onClose,
}: NotificationPopupProps) => {
  const [isVisible, setIsVisible] = useState(false);

  useEffect(() => {
    setIsVisible(true);
    const timer = setTimeout(() => {
      handleClose();
    }, 8000);

    return () => clearTimeout(timer);
  }, [notification]);

  const handleClose = () => {
    setIsVisible(false);
    setTimeout(() => {
      onClose();
    }, 300);
  };

  return (
    <div
      className={`fixed top-4 right-4 z-50 w-96 bg-white dark:bg-gray-800 rounded-lg shadow-2xl border border-gray-200 dark:border-gray-700 overflow-hidden transition-all duration-300 ${
        isVisible
          ? 'translate-x-0 opacity-100'
          : 'translate-x-full opacity-0'
      }`}
    >
      <div className="relative">
        <div className="absolute top-3 right-3">
          <button
            onClick={handleClose}
            className="text-gray-400 hover:text-gray-600 dark:hover:text-gray-300 transition-colors"
            aria-label="Close notification"
          >
            <X size={20} />
          </button>
        </div>

        <div className="p-4">
          <div className="flex items-start gap-3 mb-2">
            <div className="flex-shrink-0 mt-1">
              <div className="w-10 h-10 bg-blue-100 dark:bg-blue-900 rounded-full flex items-center justify-center">
                <Bell className="w-5 h-5 text-blue-600 dark:text-blue-300" />
              </div>
            </div>
            <div className="flex-1 min-w-0">
              <h3 className="text-lg font-semibold text-gray-900 dark:text-white mb-1 pr-6">
                {notification.title}
              </h3>
              {notification.description && (
                <p className="text-sm text-gray-600 dark:text-gray-400 mb-2">
                  {notification.description}
                </p>
              )}
            </div>
          </div>

          {notification.content && (
            <div className="pl-13 pr-2">
              <div className="text-sm text-gray-700 dark:text-gray-300 whitespace-pre-line">
                {notification.content}
              </div>
            </div>
          )}

          <div className="pl-13 mt-3">
            <p className="text-xs text-gray-500 dark:text-gray-500">
              {new Date(notification.timestamp).toLocaleString()}
            </p>
          </div>
        </div>

        <div className="h-1 bg-gradient-to-r from-blue-500 to-purple-500"></div>
      </div>
    </div>
  );
};

export default NotificationPopup;
