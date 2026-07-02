import { Link } from "react-router-dom";
import "../CSS/Home.css";
import logo from "../assets/Logo.png";

import 'bootstrap-icons/font/bootstrap-icons.css';

import {
    FaHome,
    FaUsers,
    FaStore,
    FaBoxOpen,
    FaUser,
    FaHeart,
    FaCog
} from "react-icons/fa";

import menuhamburguesa from "../assets/MenuHamburguesa.png";


import { useState } from "react";

function HomePageComponent() {
    const [menuAbierto, setMenuAbierto] = useState(false);

    const nombre = localStorage.getItem("nombre");
   

 

    return (
        <nav className="navbar">
            <img
                src={menuhamburguesa}
                onClick={() => setMenuAbierto(!menuAbierto)}
                className="Imagenes"
                alt="menu"
            />

            {menuAbierto && (
                <div className="menu">

                    <h3>MENÚ</h3>

                    <Link to="/">
                        <FaHome />
                        Inicio
                    </Link>

                    <Link to="/clientes">
                        <FaUsers />
                        Clientes
                    </Link>

                    <Link to="/tiendas/general">
                        <FaStore />
                        Tiendas
                    </Link>

                    <Link to="/productos">
                        <FaBoxOpen />
                        Productos
                    </Link>

                    <Link to="/usuario">
                        <FaUser />
                        Mi perfil
                    </Link>

                    <Link to="/favoritos">
                        <FaHeart />
                        Favoritos
                    </Link>

                    <Link to="/configuracion">
                        <FaCog />
                        Configuración
                    </Link>

                </div>
            )}

            <Link to="/">
                <img src={logo} alt="logo" className="logo" />
            </Link>

            <input
                className="input"
                type="text"
                placeholder="Buscar..."
            />

           
        

         

            <div className="usuario-info">

                <Link to="/tiendas">
                    <button>Ir a Tiendas</button>
                </Link>


                <Link to={nombre ? "/usuario" : "/login"}>
                    <i className="bi bi-person-circle logo"></i>
                </Link>

                
                       
                        <Link to="/carrito" className="carrito-link">
                            <i className="bi bi-cart"></i>
                        </Link>
                   
            </div>
        </nav>
    );
}

export default HomePageComponent;