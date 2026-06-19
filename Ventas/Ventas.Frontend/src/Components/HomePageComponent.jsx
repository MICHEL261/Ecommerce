import { Link } from "react-router-dom";
import "../CSS/Home.css";
import logo from "../assets/Logo.png";
import persona from "../assets/persona.png";

import menuhamburguesa from "../assets/MenuHamburguesa.png";
import { FaShoppingCart } from "react-icons/fa";

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
                    <Link to="/clientes">Clientes</Link>
                 
                    <Link to="/tiendas">Tiendas</Link>
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

            <Link to="/clientes">
                <button>Ir a Clientes</button>
            </Link>

        

            <Link to="/tiendas">
                <button>Ir a Tiendas</button>
            </Link>

            <Link to="/carrito">
                <FaShoppingCart size={28} color="white" />
            </Link>

            <div className="usuario-info">

                <Link to={nombre ? "/usuario" : "/login"}>
                    <img
                        src={persona}
                        alt="usuario"
                        className="logo"
                    />
                </Link>

                {nombre ? (
                    <>
                        <span className="nombre-usuario">
                            Hola, {nombre}
                        </span>

                       
                    </>
                ) : (
                    <Link to="/login">
                        Iniciar sesión
                    </Link>
                )}

            </div>
        </nav>
    );
}

export default HomePageComponent;