import { useEffect, useState } from "react";
import {
    getCarrito,
    actualizarCantidad,
    crearOrden,
 
} from "../services/carritoApi";


import HomePageComponent from "../components/HomePageComponent";
import "../CSS/carrito.css";

function CarritoPage() {
   

    const [carrito, setCarrito] = useState(null);
    const finalizarCompra = async () => {

        const clienteId =
            localStorage.getItem("clienteId");

        try {

            await crearOrden(clienteId);

            alert("Orden creada");

        } catch (error) {

            console.error(error);

        }
    };

    const actualizarCantidadItem = async (
        itemId,
        nuevaCantidad
    ) => {

        if (nuevaCantidad < 1) return;

        try {

            await actualizarCantidad(
                itemId,
                nuevaCantidad
            );

            const carritoId =
                localStorage.getItem("carritoId");

            const data =
                await getCarrito(carritoId);
            console.log(data);

            setCarrito(data);

        } catch (error) {
            console.error(error);
            alert("Error actualizando cantidad");
        }

    };

    useEffect(() => {


        const cargarCarrito = async () => {

            try {

                const carritoId =
                    localStorage.getItem("carritoId");

                const data =
                    await getCarrito(carritoId);

                setCarrito(data);

            } catch (error) {
                console.error(error);
            }
        };

        cargarCarrito();

    }, []);

    if (!carrito) {
        return <p>Cargando carrito...</p>;
    }

    const total =
        carrito.items?.reduce(
            (acum, item) =>
                acum +
                item.producto.precio *
                item.cantidad,
            0
        ) || 0;

    return (
        <>
            <HomePageComponent />

            <h1 className="text">
                Mi carrito
            </h1>

            <div className="containerprincipal">

                <div className="principal">
                    <h2>Mi carrito</h2>
                </div>

                <div className="container3">

                    <div className="Total">
                        <h2>Resumen</h2>
                        <p>Total: ${total}</p>
                        <button onClick={finalizarCompra}>
                            Finalizar compra
                        </button>
                    </div>

                    <div className="Elemento">

                        <div className="titulos-columnas">
                            <p>Imagen</p>
                            <p>Producto</p>
                            <p>Cantidad</p>
                            <p>Precio</p>
                         
                        </div>

                        {carrito.items?.map(item => (

                            <div
                                key={item.id}
                                className="item"
                            >
                                <img
                                    src={item.producto.imagen}
                                    alt={item.producto.nombre}
                                />

                                <p>
                                    {item.producto.nombre}
                                </p>

                                <div className="cantidad-control">

                                    <button
                                        onClick={() =>
                                            actualizarCantidadItem(
                                                item.id,
                                                item.cantidad - 1
                                            )
                                        }
                                    >
                                        -
                                    </button>

                                    <p>
                                        {item.cantidad}
                                    </p>

                                    <button
                                        onClick={() =>
                                            actualizarCantidadItem(
                                                item.id,
                                                item.cantidad + 1
                                            )
                                        }
                                    >
                                        
                                    </button>

                                </div>

                                <p>
                                    $
                                    {item.producto.precio}
                                </p>
                                <p>
                                    Subtotal: $
                                    {(item.producto.precio * item.cantidad).toFixed(2)}
                                </p>
                             

                            </div>

                        ))}

                    </div>

                </div>

            </div>
        </>
    );
}

export default CarritoPage;