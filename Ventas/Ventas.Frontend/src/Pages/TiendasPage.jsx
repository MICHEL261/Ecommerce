import { Link, useParams } from "react-router-dom";
import { useEffect, useState } from "react";

import "../CSS/Home.css";
import { getTiendas } from "../services/tiendasApi";
import HomePageComponent from "../components/HomePageComponent";

function TiendasPage() {
    const { id } = useParams();
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

            <div>
                <h1>Tienda {id}</h1>
            </div>

            <div className="titulo">
                <h2>🍔 Descubre sabores únicos y encuentra tu próxima comida favorita. Explora nuestras tiendas disponibles y ordena en minutos.</h2>
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
                            <p>{tienda.nombre}</p>
                        </div>
                    </Link>
                ))}
            </div>
        </>
    );
}

export default TiendasPage;