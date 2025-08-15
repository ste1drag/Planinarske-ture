import './App.css';
import { BrowserRouter, Routes } from 'react-router-dom';
import Nav from './components/layout/Nav';
import { TranslationProvider } from './contexts/TranslationContext';

function App() {
  return (
    <TranslationProvider>
      <BrowserRouter>
        <div className="App">
          <Nav />
          <Routes></Routes>
        </div>
      </BrowserRouter>
    </TranslationProvider>
  );
}

export default App;
