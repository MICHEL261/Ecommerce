import { useEffect, useState } from "react";
import { getClientes } from "../services/clientesApi";
import HomePageComponent from "../components/HomePageComponent";
import "../CSS/Clientes.css";

import { LuPencil } from "react-icons/lu";
import { useNavigate } from "react-router-dom";
import { LuTrash2 } from "react-icons/lu";
function App() {
    const navigate = useNavigate();

    const [clientes, setClientes] = useState([]);

    useEffect(() => {

        const cargarClientes = async () => {
            try {
                const data = await getClientes();
              

                setClientes(data);
            } catch (error) {
                console.log(error);
            }
        };

        cargarClientes();

    }, []);

    return (
        <>
        <HomePageComponent />
        <div>
                <h1>Lista de Clientes</h1>
                <div class="columnas">
                    <div>ID</div>
                    <div>Nombre</div>
                    <div>Apellido</div>
                    <div>Correo</div>
                    <div>Telefono</div>
                    <div>Accion</div>
                </div>

                {
                    
                clientes.length === 0
                    ? <p>No hay clientes</p>
                    : clientes.map((cliente) => (
                        <div key={cliente.id} className="fila-cliente">
                            <h3>{cliente.id}</h3>
                            <h3>{cliente.nombre}</h3>
                            <h3>{cliente.apellido}</h3>
                            <h3>{cliente.correo}</h3>
                            <h3>{cliente.telefono}</h3>
                            <div
                                className="acciones"
                            >
                                
                                <LuPencil className="accion-editar"
                                    onClick={() => navigate(`/clientes/editar/${cliente.id}`)}
                                />
                                

                                
                                    <LuTrash2 />
                                
                            </div>
                        </div>
                    ))
            }
            </div>
        </>
    );
}

export default App;
