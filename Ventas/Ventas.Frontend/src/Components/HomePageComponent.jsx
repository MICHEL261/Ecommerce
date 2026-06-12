
import { Link } from "react-router-dom";
import "../CSS/Home.css";
import logo from "../assets/Logo.png";
import persona from "../assets/persona.png";
import carrito from "../assets/carrito.png";
import menuhamburguesa from "../assets/MenuHamburguesa.png";

import { useState } from "react";
function HomePageComponent() {
    const [menuAbierto, setMenuAbierto] = useState(false);

    return (
        
        <nav className="navbar">
            <img src={menuhamburguesa} onClick={() => setMenuAbierto(!menuAbierto)} className="Imagenes" />
            {menuAbierto && (
                <div className="menu">
                    <Link to="/clientes">Clientes</Link>
                    <Link to="/productos">Productos</Link>
                    <Link to="/tiendas">Tiendas</Link>
                </div>
            )}
            <Link to="/"><img src={logo} alt="logo" className="logo" /></Link>
                <input className="input" type="text" placeholder="Buscar..." />
                <Link to="/clientes"><button>Ir a Clientes</button></Link>
                <Link to="/productos"><button>Ir a Productos</button></Link>
            <Link to="/tiendas"><button>Ir a Tiendas</button></Link>
            <Link to="/"><img src={carrito} alt="logo2" className="logo" /></Link>
            <Link to="/login"><img src={persona} alt="logo2" className="logo" /></Link>
                
               
            </nav>
            


           
        
    );
}

export default HomePageComponent;
