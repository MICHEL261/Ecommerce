
import { Link } from "react-router-dom";
import "../CSS/Home.css";
import logo from "../assets/Logo.png";

import breakfast from "../assets/breakfast.png";

function HomePage() {
    
    return (
        <div className="container">
            <nav className="navbar">
                <img src={logo} alt="logo" className="logo" />
                <input className="input" type="text" placeholder="Buscar..." />
                <Link to="/clientes"><button>Ir a Clientes</button></Link>
                <Link to="/productos"><button>Ir a Productos</button></Link>
                <Link to="/tiendas"><button>Ir a Tiendas</button></Link>
                
               
            </nav>
            <section className="seccion">
                <img src={breakfast} alt="Desayuno" className="banner-img" />

                <div className="texto-banner">
                    <h1>Bienvenido a Breakfast</h1>
                    <p>Encuentra tus restaurantes favoritos</p>
                    <Link to="/tiendas">
                    <button className="btn-principal">
                        Explorar tiendas
                        </button>
                    </Link>
                </div>
            </section>

            
          
        </div>
    );
}

export default HomePage;
