import axios from "axios";

const API_URL = "http://localhost:5186/api/Categorias";

export const getCategorias = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};