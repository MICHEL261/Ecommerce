import axios from "axios";

const API_URL = "http://localhost:5186/api/Carrito";

export const agregarProducto = async (carritoId, productoId, cantidad) => {
    const response = await axios.post(
        `${API_URL}/${carritoId}/productos`,
        {
            productoId,
            cantidad
        }
    );

    return response.data;
};

export const eliminarProducto = async (itemId) => {
    const response = await axios.delete(`${API_URL}/item/${itemId}`);
    return response.data;
};

export const getCarrito = async (carritoId) => {
    const response = await axios.get(`${API_URL}/${carritoId}`);
    return response.data;
};

export const updateCliente = async (carrito) => {
    const response = await axios.put(API_URL, carrito);
    return response.data;
};
export const crearOrden = async (clienteId) => {
    const response = await axios.post(
        "http://localhost:5186/api/Carrito/crear",
        { clienteId }
    );

    return response.data;
};

export const actualizarCantidad = async (
    itemId,
    cantidad
) => {

    const response = await axios.put(
        `${API_URL}/item/${itemId}`,
        {
            cantidad
        }
    );

    return response.data;
};