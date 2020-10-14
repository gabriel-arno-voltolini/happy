import React from 'react';
import {FiArrowRight} from 'react-icons/fi';

import '../src/styles/global.css';
import '../src/styles/Pages/landing.css';

import logoImg from './images/logo-light.svg';

function App() {
  return (
    <div id="page-landing">
     <div className="content-wrapper">
       <img src={logoImg} alt="Happy"/>

       <main>
         <h1>Leve felicidade para o mundo</h1>
         <p>Visite o orfanato e mude o dia de muitas crianças</p>
       </main>

      <div className="location">
       <strong>Timbó</strong>
       <span>Santa Catarina</span>
     </div>
        <a href="" className="enter-app"> 
          <FiArrowRight size = {26} color="rgba(0,0,0,0.6)"/>
       </a>
     </div>
    </div>
  );
}

export default App;
