import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import {
    getCarrito,
    actualizarCantidad,
    crearOrden,
} from "../services/carritoApi";

import HomePageComponent from "../components/HomePageComponent";
import "../CSS/carrito.css";

function CarritoPage() {

    const [carrito, setCarrito] = useState(null);

    const navigate = useNavigate();

    const finalizarCompra = async () => {

        const clienteId = localStorage.getItem("clienteId");

        try {

            await crearOrden(clienteId);

            alert("Orden creada correctamente");

        } catch (error) {

            console.error(error);

        }
    };

    const actualizarCantidadItem = async (itemId, cantidad) => {

        if (cantidad < 1) return;

        try {

            await actualizarCantidad(itemId, cantidad);

            const carritoId = localStorage.getItem("carritoId");

            const data = await getCarrito(carritoId);

            setCarrito(data);

        } catch (error) {

            console.error(error);

        }

    };

    useEffect(() => {

        const cargar = async () => {

            const carritoId = localStorage.getItem("carritoId");

            const data = await getCarrito(carritoId);
            console.log(data.items);

            setCarrito(data);

        };

        cargar();

    }, []);

    if (!carrito) {

        return <p>Cargando...</p>;

    }

    const total =
        carrito.items?.reduce(
            (a, item) =>
                a +
                item.producto.precio *
                item.cantidad,
            0
        ) || 0;

    return (
        <>
            <HomePageComponent />

            <div className="titulo-carrito">

                <h1>🛒 Mi carrito</h1>

                <p>
                    {carrito.items.length} productos agregados
                </p>

            </div>

            <div className="containerprincipal">

                <div className="container3">

                    <div className="Total">

                        <h2>Resumen del pedido</h2>

                        <div className="linea-total">

                            <span>Productos</span>

                            <span>{carrito.items.length}</span>

                        </div>

                        <div className="linea-total">

                            <span>Subtotal</span>

                            <span>${total.toFixed(2)}</span>

                        </div>

                        <div className="linea-total">

                            <span>Envío</span>

                            <span className="gratis">
                                Gratis
                            </span>

                        </div>

                        <hr />

                        <div className="linea-final">

                            <span>Total</span>

                            <span>${total.toFixed(2)}</span>

                        </div>

                        <div className="beneficios">

                            <p>✔ Pago seguro</p>

                            <p>✔ Compra protegida</p>

                            <p>✔ Entrega rápida</p>

                        </div>

                        <button
                            onClick={finalizarCompra}
                        >
                            Finalizar compra
                        </button>

                        <button
                            className="seguir"
                            onClick={() => navigate("/")}
                        >
                            Seguir comprando
                        </button>

                    </div>

                    <div className="Elemento">

                        <div className="titulos-columnas">

                            <p>Imagen</p>

                            <p>Producto</p>

                            <p>Cantidad</p>

                            <p>Precio</p>

                        </div>

                        {carrito.items.map(item => (

                            <div
                                key={item.id}
                                className="item"
                            >

                                <div>

                                    <img
                                        src={item.producto.imagen}
                                        alt=""
                                    />

                                    <p className="subtotal">
                                        Subtotal:
                                        $
                                        {(item.producto.precio * item.cantidad).toFixed(2)}
                                    </p>

                                </div>

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

                                    <span>

                                        {item.cantidad}

                                    </span>

                                    <button
                                        onClick={() =>
                                            actualizarCantidadItem(
                                                item.id,
                                                item.cantidad + 1
                                            )
                                        }
                                    >
                                        +

                                    </button>

                                </div>

                                <p>

                                    ${item.producto.precio}

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