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
import Landing from './pages/Landing';
import Login from './pages/Login';
import Mountains from './pages/Mountains';
import Notifications from './pages/Notifications';
import Profile from './pages/Profile';
import Tours from './pages/Tours';

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const user = useAuthStore(state => state.user);
  if (!user) {
    return <Navigate to="/" replace />;
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

  return (
    <div className="min-h-screen bg-background">
      {!hideNav && <Nav />}
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
          path="/notifications"
          element={
            <ProtectedRoute>
              <Notifications />
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
