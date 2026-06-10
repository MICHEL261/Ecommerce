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