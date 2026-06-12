import { useParams, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import { getCliente, updateCliente } from "../services/clientesApi";

function EditarClientePage() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [cliente, setCliente] = useState({
        id: 0,
        nombre: "",
        apellido: "",
        email: "",
        telefono: "",
        direccion: ""
    });

 

    useEffect(() => {
        const cargarCliente = async () => {
            try {
                const data = await getCliente(id);
                setCliente(data);
            } catch (error) {
                console.error("Error cargando cliente:", error);
            }
        };

        cargarCliente     ();
    }, [id]);


    const guardar = async (e) => {
        e.preventDefault();

        try {
            console.log(cliente);
            await updateCliente(cliente);
            alert("Cliente actualizado correctamente");
            navigate("/clientes");
        } catch (error) {
            console.error("Error actualizando cliente:", error);
            alert("Error al actualizar cliente");
        }
    };

    return (
        <div>
            <h1>Editar Cliente</h1>

            <form onSubmit={guardar}>

                <div>
                    <label>Nombre</label>
                    <input
                        type="text"
                        value={cliente.nombre}
                        onChange={(e) =>
                            setCliente({
                                ...cliente,
                                nombre: e.target.value
                            })
                        }
                    />
                </div>

                <div>
                    <label>Apellido</label>
                    <input
                        type="text"
                        value={cliente.apellido}
                        onChange={(e) =>
                            setCliente({
                                ...cliente,
                                apellido: e.target.value
                            })
                        }
                    />
                </div>

                <div>
                    <label>Email</label>
                    <input
                        type="email"
                        value={cliente.email}
                        onChange={(e) =>
                            setCliente({
                                ...cliente,
                                email: e.target.value
                            })
                        }
                    />
                </div>

                <div>
                    <label>Teléfono</label>
                    <input
                        type="text"
                        value={cliente.telefono}
                        onChange={(e) =>
                            setCliente({
                                ...cliente,
                                telefono: e.target.value
                            })
                        }
                    />
                </div>

                <div>
                    <label>Dirección</label>
                    <input
                        type="text"
                        value={cliente.direccion}
                        onChange={(e) =>
                            setCliente({
                                ...cliente,
                                direccion: e.target.value
                            })
                        }
                    />
                </div>

                <button type="submit">
                    Guardar cambios
                </button>

            </form>
        </div>
    );
}

export default EditarClientePage;