import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { createCliente } from "../services/clientesApi";
import HomePageComponent from "../components/HomePageComponent";
import "../CSS/EditarCliente.css";

function CrearClientePage() {

    const navigate = useNavigate();

    const [cliente, setCliente] = useState({
        nombre: "",
        apellido: "",
        email: "",
        telefono: "",
        direccion: "",
        password: ""
    });

    const guardar = async (e) => {
        e.preventDefault();

        try {

            await createCliente(cliente);

            alert("Cliente creado correctamente");

            navigate("/clientes");

        } catch (error) {

            console.error(error);
            alert("Error al crear cliente");

        }
    };

    return (
        <>
            <HomePageComponent />

            <div className="editar-container">

                <div className="editar-card">

                    <h1>Crear Cliente</h1>

                    <form onSubmit={guardar} className="edicion">

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

                        <div>
                            <label>Contraseña</label>
                            <input
                                type="password"
                                value={cliente.password}
                                onChange={(e) =>
                                    setCliente({
                                        ...cliente,
                                        password: e.target.value
                                    })
                                }
                            />
                        </div>

                        <button type="submit">
                            Crear cliente
                        </button>

                    </form>

                </div>

            </div>
        </>
    );
}

export default CrearClientePage;