import axios from "axios";

const API_URL = "http://localhost:5186/api/Clientes";

export const getClientes = async () => {
    const response = await axios.get(API_URL);
    return response.data; 
};
export const updateCliente = async (cliente) => {
    const response = await axios.put(API_URL, cliente);
    return response.data;
};
export const getCliente = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};
export const deleteCliente = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};
export const createCliente = async (cliente) => {
    const response = await axios.post(API_URL, cliente);
    return response.data;
};