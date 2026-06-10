import axios from "axios";

const API_URL = "http://localhost:5186/api/Productos";

export const getProductos = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};