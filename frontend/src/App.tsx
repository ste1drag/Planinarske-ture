import React from 'react';
import './App.css';
import Nav from "./components/Nav/Nav";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import {homeEndpoint, tourEndpoint, toursEndpoint} from "./utils/apiEndpoints";
import Home from "./components/Home/Home";
import Tours from "./components/Tours/Tours";
import TourInfo from "./components/TourInfo/TourInfo";


function App() {
  return (
      <BrowserRouter>
        <div className="App">
                <Nav/>
                <Routes>
                    <Route path={homeEndpoint} element={<Home/>} />
                    <Route path={toursEndpoint} element={<Tours/>} />
                    <Route path={tourEndpoint} element={<TourInfo/>} />
                </Routes>
        </div>
      </BrowserRouter>
  );
}

export default App;
