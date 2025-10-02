import './App.css';
import { BrowserRouter, Routes, Route, useLocation } from 'react-router-dom';
import Nav from './components/layout/Nav';
import { TranslationProvider } from './contexts/TranslationContext';
import Landing from './pages/Landing';
import Login from './pages/Login';
import Mountains from './pages/Mountains';
import Notifications from './pages/Notifications';
import Profile from './pages/Profile';
import Tours from './pages/Tours';

function AppContent() {
  const location = useLocation();
  const hideNav = location.pathname === '/login';

  return (
    <div className="min-h-screen bg-background">
      {!hideNav && <Nav />}
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/home" element={<Landing />} />
        <Route path="/tours" element={<Tours />} />
        <Route path="/mountains" element={<Mountains />} />
        <Route path="/notifications" element={<Notifications />} />
        <Route path="/profile" element={<Profile />} />
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
