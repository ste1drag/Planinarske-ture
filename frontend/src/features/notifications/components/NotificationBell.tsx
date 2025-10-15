import { Bell } from 'lucide-react';
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useNotificationStore } from '../store/notification-store';
import { Button } from '@/components/ui/Button';

export const NotificationBell = () => {
  const { stats, fetchStats } = useNotificationStore();
  const navigate = useNavigate();

  useEffect(() => {
    fetchStats();
  }, [fetchStats]);

  const handleClick = () => {
    navigate('/notifications');
  };

  return (
    <Button
      variant="ghost"
      size="icon"
      className="relative"
      onClick={handleClick}
    >
      <Bell className="h-5 w-5" />
      {stats && stats.unreadCount > 0 && (
        <span className="absolute top-0 right-0 h-4 w-4 rounded-full bg-red-500 text-xs text-white flex items-center justify-center">
          {stats.unreadCount > 9 ? '9+' : stats.unreadCount}
        </span>
      )}
    </Button>
  );
};
