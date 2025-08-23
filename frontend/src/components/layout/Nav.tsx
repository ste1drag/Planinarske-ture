import { Mountain, Calendar, MessageSquare, Bell, User } from 'lucide-react';
import { Link, useLocation } from 'react-router-dom';
import { useTranslation } from '@/contexts/TranslationContext';
import { cn } from '@/lib/utils';

const Nav = () => {
  const location = useLocation();
  const t = useTranslation();

  const navigationItems = [
    { name: t.tours, href: '/tours', icon: Calendar },
    { name: t.mountains, href: '/mountains', icon: Mountain },
    { name: t.reviews, href: '/reviews', icon: MessageSquare },
    { name: t.notifications, href: '/notifications', icon: Bell },
    { name: t.profile, href: '/profile', icon: User },
  ];

  return (
    <nav className="sticky top-0 z-50 w-full border-b bg-card/95 backdrop-blur supports-[backdrop-filter]:bg-card/60">
      <div className="flex h-16 items-center justify-between">
        <Link to="/" className="flex items-center space-x-2">
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
                    ? 'bg-forest text-white'
                    : 'text-muted-foreground hover:text-foreground hover:bg-muted'
                )}
              >
                <item.icon className="h-4 w-4" />
                <span>{item.name}</span>
              </Link>
            );
          })}
        </div>
      </div>
    </nav>
  );
};

export default Nav;
