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

        const carritoId = localStorage.getItem("carritoId");

        if (!carritoId) {
            alert("Debes iniciar sesión para agregar productos al carrito");
            return;
        }

        try {

            console.log("carritoId:", carritoId);
            console.log("productoId:", productoId);

            await agregarProducto(
                Number(carritoId),
                productoId,
                1
            );

            alert("Producto agregado al carrito");
        }
        catch (error) {
            console.error(error);
            console.log(error.response?.data);
            alert(JSON.stringify(error.response?.data));
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

                        <h1>{tienda.nombre}</h1>

                        <div className="info">

                            <p>
                                📧 <strong>{tienda.email}</strong>
                            </p>

                            <p>
                                📞 <strong>{tienda.telefono}</strong>
                            </p>

                            <p>
                                📍 <strong>{tienda.direccion}</strong>
                            </p>

                        </div>

                    </div>

                </div>

                <div className="titulo-productos">

                    <h2>Nuestro menú</h2>

                    <span>
                        {tienda.productos?.length} productos disponibles
                    </span>

                </div>

                <div className="productos-grid">

                    {tienda.productos?.map((producto) => (

                        <div
                            key={producto.id}
                            className="productos"
                        >

                            <img
                                src={producto.imagen}
                                alt={producto.nombre}
                                className="producto-img"
                            />

                            <div className="producto-info">

                                <h3>{producto.nombre}</h3>

                                <p className="descripcion">
                                    {producto.descripcion}
                                </p>

                                <div className="footer-producto">

                                    <span className="precio">
                                        ${producto.precio}
                                    </span>

                                    <button
                                        className="btn-carrito"
                                        onClick={() =>
                                            agregarAlCarrito(producto.id)
                                        }
                                    >
                                        🛒 Agregar
                                    </button>

                                </div>

                            </div>

                        </div>

                    ))}

                </div>

            </div>

        </>
    );
}

export default DetalleTiendaPage;