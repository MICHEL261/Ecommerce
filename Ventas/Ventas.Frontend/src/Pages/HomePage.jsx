import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "../CSS/Home.css";
import logo from "../assets/Logo.png";
import { getTiendas } from "../services/tiendasApi";

function HomePage() {
    const [tiendas, setTiendas] = useState([]);

    useEffect(() => {
        const cargarTiendas = async () => {
            try {
                const data = await getTiendas();
                setTiendas(data);
            } catch (error) {
                console.error("Error cargando tiendas:", error);
            }
        };
        cargarTiendas();
    }, []);

    return (
        <div className="container">
            <nav className="navbar">
                <img src={logo} alt="logo" className="logo" />
                <Link to="/clientes"><button>Ir a Clientes</button></Link>
                <Link to="/productos"><button>Ir a Productos</button></Link>
                <Link to="/tiendas"><button>Ir a Tiendas</button></Link>
                <input type="text" placeholder="Buscar..." />
            </nav>

            <h1>Inicio</h1>
            <h2>Tiendas disponibles</h2>

            <div className="tiendas-grid">
                {tiendas.map((tienda) => (
                    <div key={tienda.id} className="tienda-card">
                        <img src={tienda.imagen} alt={tienda.nombre} className="tienda-img" />
                        <p>{tienda.nombre}</p>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default HomePage;
