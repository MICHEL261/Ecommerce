import { Link } from "react-router-dom";
import "../CSS/Home.css";
import logo from "../assets/Logo.png";

function HomePage() {

    return (
        <div className="container">

            <nav className="navbar">

                <img src={logo} alt="logo" className="logo" />

                <Link to="/clientes">
                    <button>Ir a Clientes</button>
                </Link>

                <Link to="/productos">
                    <button>Ir a Productos</button>
                </Link>

                <Link to="/Tiendas">
                    <button>Ir a Tiendas</button>
                </Link>
                <input type="text" placeholder="Buscar..." />

            </nav>

            <h1>Inicio</h1>
            <h1>Bienvenido</h1>

        </div>
    );
}

export default HomePage;