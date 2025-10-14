import { useEffect, useState } from 'react';
import NotificationPopup from './NotificationPopup';
import { signalRService } from '../services/signalr-service';
import { Notification } from '../types/notification';

const NotificationContainer = () => {
  const [notifications, setNotifications] = useState<Notification[]>([]);

  useEffect(() => {
    const initializeSignalR = async () => {
      try {
        await signalRService.startConnection();
      } catch (error) {
        console.error('Failed to start SignalR connection:', error);
      }
    };

    initializeSignalR();

    const unsubscribe = signalRService.onNotification(
      (notification: Notification) => {
        setNotifications(prev => [...prev, notification]);
      }
    );

    return () => {
      unsubscribe();
      signalRService.stopConnection();
    };
  }, []);

  const handleCloseNotification = (notificationId: string) => {
    setNotifications(prev =>
      prev.filter(notification => notification.id !== notificationId)
    );
  };

  return (
    <>
      {notifications.map((notification, index) => (
        <div
          key={notification.id}
          style={{
            transform: `translateY(${index * 10}px)`,
          }}
        >
          <NotificationPopup
            notification={notification}
            onClose={() => handleCloseNotification(notification.id)}
          />
        </div>
      ))}
    </>
  );
};

export default NotificationContainer;
