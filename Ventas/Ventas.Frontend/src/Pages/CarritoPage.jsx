import { useEffect, useState } from "react";
import { getCarrito } from "../services/carritoApi";

function CarritoPage() {

    const [carrito, setCarrito] = useState(null);

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

    return (
        <div>
            <h1>Mi carrito</h1>

            {carrito.items?.map(item => (
                <div key={item.id}>

                    <h3>{item.producto.nombre}</h3>

                    <p>
                        Cantidad: {item.cantidad}
                    </p>

                    <p>
                        Precio: ${item.producto.precio}
                    </p>

                </div>
            ))}
        </div>
    );
}

export default CarritoPage;