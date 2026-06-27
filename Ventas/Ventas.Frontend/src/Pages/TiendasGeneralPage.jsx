import { useEffect, useState } from "react";

import HomePageComponent from "../components/HomePageComponent";
import "../CSS/TiendasGeneral.css";

import { LuPencil, LuTrash2 } from "react-icons/lu";
import { FaPlus } from "react-icons/fa";
import { useNavigate } from "react-router-dom";
import { getTiendas } from "../services/tiendasApi";

function TiendasGeneralPage() {
    const navigate = useNavigate();

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

            <div className="clientes-container">

                <div className="clientes-header">

                    <h1>Tiendas</h1>

                    <button
                        className="btn-agregar"
                        onClick={() => navigate("/tiendas/crear")}
                    >
                        <FaPlus />
                        Agregar tienda
                    </button>

                </div>

                <div className="tabla-clientes">

                    <div className="tabla-header">
                        <span>ID</span>
                        <span>Nombre</span>
                        <span>Email</span>
                        <span>Telefono</span>
                        <span>Direccion</span>
                        <span>Descripcions</span>
                    
                        <span>Categoria</span>
                        <span>Acciones</span>
                    </div>

                    {tiendas.length === 0 ? (

                        <div className="sin-datos">
                            No hay tiendas registradas.
                        </div>

                    ) : (

                        tiendas.map((tienda) => (

                            <div
                                key={tienda.id}
                                className="fila-cliente"
                            >

                                <span>{tienda.id}</span>

                                <span>{tienda.nombre}</span>

                                <span>{tienda.email}</span>

                                <span>{tienda.telefono}</span>

                                <span>{tienda.direccion}</span>

                                <span>{tienda.descripcion}</span>

                        

                                <span>{tienda.categoria}</span>

                                <div className="acciones">

                                    <button
                                        className="btn-icon editar"
                                        onClick={() =>
                                            navigate(`/tiendas/editar/${tienda.id}`)
                                        }
                                    >
                                        <LuPencil />
                                    </button>

                                    <button className="btn-icon eliminar">
                                        <LuTrash2 />
                                    </button>

                                </div>

                            </div>

                        ))

                    )}

                </div>

            </div>
        </>
    );
}

export default TiendasGeneralPage;