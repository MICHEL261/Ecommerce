import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";

import HomePageComponent from "../components/HomePageComponent";
import { getTienda } from "../services/tiendasApi";
import { agregarProducto } from "../services/carritoApi";
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

    const agregarAlCarrito = async (productoId) => {
        try {
            const carritoId = 1; // por ahora fijo

            await agregarProducto(carritoId, productoId, 1);

            alert("Producto agregado al carrito");
        } catch (error) {
            console.error(error);
            alert("Error al agregar producto");
        }
    };

    if (!tienda) {
        return <p>Cargando...</p>;
    }

    return (
        <>
            <HomePageComponent />

            <div className="detalle-tienda">

                <div className="container2">

                    <div className="imagen">
                        <img
                            src={tienda.imagen}
                            alt={tienda.nombre}
                        />
                    </div>

                    <div className="texto">
                        <em>
                            <h1>{tienda.nombre}</h1>
                        </em>

                        <p>
                            <strong>
                                Correo electrónico: {tienda.email}
                            </strong>
                        </p>

                        <p>
                            <strong>
                                Teléfono: {tienda.telefono}
                            </strong>
                        </p>

                        <p>
                            <strong>
                                Dirección: {tienda.direccion}
                            </strong>
                        </p>
                    </div>

                </div>

                <h2>Productos</h2>

                <div className="productos-grid">

                    {tienda.productos?.map((producto) => (
                        <div
                            className="productos"
                            key={producto.id}
                        >
                            <img
                                src={producto.imagen}
                                alt={producto.nombre}
                                className="producto-img"
                            />

                            <h3>{producto.nombre}</h3>

                            <p>${producto.precio}</p>

                            <button
                                onClick={() =>
                                    agregarAlCarrito(producto.id)
                                }
                            >
                                Agregar al carrito
                            </button>
                        </div>
                    ))}

                </div>

            </div>
        </>
    );
}

export default DetalleTiendaPage;