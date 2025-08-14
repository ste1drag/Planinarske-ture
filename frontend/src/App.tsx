import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Nav from './components/layout/Nav';
import { TranslationProvider } from './contexts/TranslationContext';
import {
  Tours,
  AddTour,
  TourInfo,
  addTourEndpoint,
  homeEndpoint,
  toursEndpoint,
} from './features/tours';
import Home from './pages/Home';

function App() {
  return (
    <TranslationProvider>
      <BrowserRouter>
        <div className="App">
          <Nav />
          <Routes>
            <Route path={homeEndpoint} element={<Home />} />
            <Route path={toursEndpoint} element={<Tours />} />
            <Route path={toursEndpoint} element={<TourInfo />} />
            <Route path={addTourEndpoint} element={<AddTour />} />
          </Routes>
        </div>
      </BrowserRouter>
    </TranslationProvider>
  );
}

export default App;
