import './App.css';
import { useEffect } from 'react';
import {
  BrowserRouter,
  Routes,
  Route,
  useLocation,
  Navigate,
} from 'react-router-dom';
import Nav from './components/layout/Nav';
import { TranslationProvider } from './contexts/TranslationContext';
import { useAuthStore } from './features/auth/store/auth-store';
import NotificationContainer from './features/notification/components/NotificationContainer';
import Admin from './pages/Admin';
import Landing from './pages/Landing';
import Login from './pages/Login';
import Mountains from './pages/Mountains';
import Profile from './pages/Profile';
import Tours from './pages/Tours';

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const user = useAuthStore(state => state.user);
  if (!user) {
    return <Navigate to="/" replace />;
  }
  return <>{children}</>;
}

function AdminRoute({ children }: { children: React.ReactNode }) {
  const user = useAuthStore(state => state.user);
  if (!user) {
    return <Navigate to="/" replace />;
  }
  if (!user.roles?.includes('Administrator')) {
    return <Navigate to="/home" replace />;
  }
  return <>{children}</>;
}

function AppContent() {
  const location = useLocation();
  const hideNav = location.pathname === '/';
  const initializeAuth = useAuthStore(state => state.initializeAuth);

  useEffect(() => {
    initializeAuth();
  }, [initializeAuth]);

  const user = useAuthStore(state => state.user);

  return (
    <div className="min-h-screen bg-background">
      {!hideNav && <Nav />}
      {user && <NotificationContainer />}
      <Routes>
        <Route path="/" element={<Login />} />
        <Route
          path="/home"
          element={
            <ProtectedRoute>
              <Landing />
            </ProtectedRoute>
          }
        />
        <Route
          path="/tours"
          element={
            <ProtectedRoute>
              <Tours />
            </ProtectedRoute>
          }
        />
        <Route
          path="/mountains"
          element={
            <ProtectedRoute>
              <Mountains />
            </ProtectedRoute>
          }
        />
        <Route
          path="/profile"
          element={
            <ProtectedRoute>
              <Profile />
            </ProtectedRoute>
          }
        />
        <Route
          path="/admin"
          element={
            <AdminRoute>
              <Admin />
            </AdminRoute>
          }
        />
      </Routes>
    </div>
  );
}

function App() {
  return (
    <TranslationProvider>
      <BrowserRouter>
        <AppContent />
      </BrowserRouter>
    </TranslationProvider>
  );
}

export default App;
