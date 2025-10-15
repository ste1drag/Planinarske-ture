<<<<<<< HEAD
import { Mountain, Calendar, Bell, User, LogOut, Shield } from 'lucide-react';
=======
import { Mountain, Calendar, User, LogOut } from 'lucide-react';
>>>>>>> origin/main
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { useTranslation } from '@/contexts/TranslationContext';
import { useAuthStore } from '@/features/auth/store/auth-store';
import { NotificationBell } from '@/features/notifications';
import { cn } from '@/lib/utils';

const Nav = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const t = useTranslation();
  const logout = useAuthStore(state => state.logout);
  const user = useAuthStore(state => state.user);

  const handleLogout = async () => {
    await logout();
    navigate('/');
  };

  const navigationItems = [
    { name: t.tours, href: '/tours', icon: Calendar },
    { name: t.mountains, href: '/mountains', icon: Mountain },
    { name: t.profile, href: '/profile', icon: User },
  ];

  const isAdmin = user?.roles?.includes('Administrator');

  return (
    <nav className="sticky top-0 px-3 z-50 w-full border-b bg-card/95 backdrop-blur supports-[backdrop-filter]:bg-card/60">
      <div className="flex h-16 items-center justify-between">
        <Link to="/home" className="flex items-center space-x-2">
          <Mountain className="h-8 w-8 text-forest" />
          <span className="text-xl font-bold bg-gradient-to-r from-forest to-mountain bg-clip-text text-transparent">
            {t.mountainTours}
          </span>
        </Link>
        <div className="hidden md:flex items-center space-x-1">
          {navigationItems.map(item => {
            const isActive = location.pathname === item.href;
            return (
              <Link
                key={item.name}
                to={item.href}
                className={cn(
                  'flex items-center space-x-2 px-3 py-2 rounded-md text-sm font-medium transition-colors',
                  isActive
                    ? 'bg-forest-light text-white'
                    : 'text-muted-foreground hover:text-foreground hover:bg-muted'
                )}
              >
                <item.icon className="h-4 w-4" />
                <span>{item.name}</span>
              </Link>
            );
          })}
<<<<<<< HEAD
          {isAdmin && (
            <Link
              to="/admin"
              className={cn(
                'flex items-center space-x-2 px-3 py-2 rounded-md text-sm font-medium transition-colors',
                location.pathname === '/admin'
                  ? 'bg-forest-light text-white'
                  : 'text-muted-foreground hover:text-foreground hover:bg-muted'
              )}
            >
              <Shield className="h-4 w-4" />
              <span>Admin</span>
            </Link>
          )}
=======
          <NotificationBell />
>>>>>>> origin/main
          <button
            onClick={handleLogout}
            className="flex items-center space-x-2 px-3 py-2 rounded-md text-sm font-medium transition-colors text-muted-foreground hover:text-foreground hover:bg-muted"
          >
            <LogOut className="h-4 w-4" />
            <span>Logout</span>
          </button>
        </div>
      </div>
    </nav>
  );
};

export default Nav;
