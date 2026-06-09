import axios from "axios";

const API_URL = "http://localhost:5186/api/Tiendas";

export const getTiendas = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getTienda = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};