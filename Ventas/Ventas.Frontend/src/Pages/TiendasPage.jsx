import { Link } from "react-router-dom";
import { useEffect, useState } from "react";

import "../CSS/Home.css";
import { getTiendas } from "../services/tiendasApi";
import HomePageComponent from "../components/HomePageComponent";

function TiendasPage() {
    
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
        <>

            <HomePageComponent />

         
            <div className="banner-tiendas">

                <h1>🍔 ¿Qué vas a pedir hoy?</h1>

                <p>
                    Descubre restaurantes, cafeterías, supermercados y farmacias
                    cerca de ti.
                </p>

            </div>
            <div className="tiendas-grid">
                {tiendas.map((tienda) => (
                    <Link
                        key={tienda.id}
                        to={`/tienda/${tienda.id}`}
                        className="tienda-link"
                    >
                        <div className="tienda-card">
                            <img
                                src={tienda.imagen}
                                alt={tienda.nombre}
                                className="tienda-img"
                            />
                            <h2 className="tienda-nombre">
                                {tienda.nombre}
                            </h2>

                            <p className="tienda-categoria">
                                Restaurante
                            </p>
                        </div>
                    </Link>
                ))}
            </div>
        </>
    );
}

export default TiendasPage;