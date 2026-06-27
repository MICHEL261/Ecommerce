import { useEffect, useState } from "react";

import HomePageComponent from "../components/HomePageComponent";
import "../CSS/Productos.css";

import { LuPencil, LuTrash2 } from "react-icons/lu";
import { FaPlus } from "react-icons/fa";
import { useNavigate } from "react-router-dom";
import { getProductos } from "../services/ProductosApi";

function ProductosPage () {
    const navigate = useNavigate();

    const [productos, setProductos] = useState([]);

    useEffect(() => {
        const cargarProductos = async () => {
            try {
                const data = await getProductos();
                setProductos(data);
            } catch (error) {
                console.error("Error cargando productos:", error);
            }
        };

        cargarProductos();
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
                        <span>Precio</span>
                        <span>Tienda</span>
                        <span>Descripción</span>
                  
                        <span>Acciones</span>
                    </div>

                    {productos.length === 0 ? (

                        <div className="sin-datos">
                            No hay productos registrados.
                        </div>

                    ) : (

                        productos.map((producto) => (

                            <div
                                key={producto.id}
                                className="fila-cliente"
                            >

                                <span>{producto.id}</span>

                                <span>{producto.nombre}</span>

                                <span>{producto.precio}</span>
                               

                                <span>{producto.descripcion}</span>


                                <div className="acciones">

                                    <button
                                        className="btn-icon editar"
                                        onClick={() =>
                                            navigate(`/productos/editar/${producto.id}`)
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

export default ProductosPage;