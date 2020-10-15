import React from 'react';
import {Link} from 'react-router-dom';
import {FiPlus} from 'react-icons/fi';
import {Map, TileLayer} from 'react-leaflet';

import MapMarkerImg from '../images/map-marker-light.svg';

import '../styles/pages/orphanages-map.css';
import 'leaflet/dist/leaflet.css';

function OrphanageMap(){
    return(
      <div id="page-map">
            <aside>
                <header>
                    <img src={MapMarkerImg} alt="Happy"/>
                    <h2>Esolha um orfanato no mapa</h2>
                    <p>Muitas crianças estão esperando a sua visita :)</p>
                </header>
                <footer>
                    <strong>Timbó</strong>
                    <span>Santa Catarina</span>
                </footer>
            </aside>
           
             <Map
             center = {[-26.8126418,-49.2668968]}
             zoom = {15}
             style = {{width :'100%', height: '100%'}}
             >
                 <TileLayer url="https://a.tile.openstreetmap.org/{z}/{x}/{y}.png" />
            </Map>
            <Link to ="" className = "create-orphanage">
                <FiPlus size = {32} color="#FFF"/>
            </Link>
       
      </div>     
    );
}

export default OrphanageMap;