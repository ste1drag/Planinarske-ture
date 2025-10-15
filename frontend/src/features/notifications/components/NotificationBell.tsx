import { Bell } from 'lucide-react';
import { useEffect } from 'react';
import { NotificationList } from './NotificationList';
import { useNotificationStore } from '../store/notification-store';
import { Button } from '@/components/ui/Button';
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/components/ui/popover';

export const NotificationBell = () => {
  const { stats, fetchStats } = useNotificationStore();

  useEffect(() => {
    fetchStats();
  }, [fetchStats]);

  return (
    <Popover>
      <PopoverTrigger asChild>
        <Button variant="ghost" size="icon" className="relative">
          <Bell className="h-5 w-5" />
          {stats && stats.unreadCount > 0 && (
            <span className="absolute top-0 right-0 h-4 w-4 rounded-full bg-red-500 text-xs text-white flex items-center justify-center">
              {stats.unreadCount > 9 ? '9+' : stats.unreadCount}
            </span>
          )}
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-80 p-0" align="end">
        <NotificationList />
      </PopoverContent>
    </Popover>
  );
};
