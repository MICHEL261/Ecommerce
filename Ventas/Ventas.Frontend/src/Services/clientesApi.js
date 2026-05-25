import axios from "axios";

const API_URL = "http://localhost:5186/api/Clientes";

export const getClientes = async () => {
    const response = await axios.get(API_URL);
    return response.data; 
};
