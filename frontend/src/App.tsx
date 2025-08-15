import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Nav from './components/layout/Nav';
import { TranslationProvider } from './contexts/TranslationContext';
import Home from './pages/Home';
import Mountains from './pages/Mountains';
import Notifications from './pages/Notifications';
import Profile from './pages/Profile';
import Reviews from './pages/Reviews';
import Tours from './pages/Tours';

function App() {
  return (
    <TranslationProvider>
      <BrowserRouter>
        <div className="min-h-screen bg-background">
          <Nav />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/tours" element={<Tours />} />
            <Route path="/mountains" element={<Mountains />} />
            <Route path="/reviews" element={<Reviews />} />
            <Route path="/notifications" element={<Notifications />} />
            <Route path="/profile" element={<Profile />} />
          </Routes>
        </div>
      </BrowserRouter>
    </TranslationProvider>
  );
}

export default App;
