import { useEffect, useState } from "react";
import { getClientes } from "../services/clientesApi";
import HomePageComponent from "../components/HomePageComponent";

function App() {

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

            {
                clientes.length === 0
                    ? <p>No hay clientes</p>
                    : clientes.map((cliente) => (
                        <div key={cliente.id}>
                            <p>ID: {cliente.id}</p>
                            <p>Nombre: {cliente.nombre}</p>
                            <hr />
                        </div>
                    ))
            }
            </div>
        </>
    );
}

export default App;
