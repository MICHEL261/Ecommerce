import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";

import HomePageComponent from "../components/HomePageComponent";
import { getTienda } from "../services/tiendasApi";
import "../CSS/DetalleTiendas.css";

function DetalleTiendaPage() {
    const { id } = useParams();

    const [tienda, setTienda] = useState(null);

    useEffect(() => {
        const cargarTienda = async () => {
            try {
                const data = await getTienda(id);
                setTienda(data);
            } catch (error) {
                console.error(error);
            }
        };

        cargarTienda();
    }, [id]);

    if (!tienda) {
        return <p>Cargando...</p>;
    }

    return (
        <>
            <HomePageComponent />
            <h1>{tienda.nombre}</h1>

            <div className="detalle-tienda">

                <div className="imagen">
                    <img src={tienda.imagen} alt={tienda.nombre} />
                </div>

                <div className="texto">
                    <h1>{tienda.nombre}</h1>
                    <p>Correo electrónico: {tienda.email}</p>
                    <p>Teléfono: {tienda.telefono}</p>
                    <p>Dirección: {tienda.direccion}</p>
                </div>

            </div>
        </>
    );
}

export default DetalleTiendaPage;