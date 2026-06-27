import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import HomePageComponent from "../components/HomePageComponent";
import { createTienda } from "../services/tiendasApi";
import { getCategorias } from "../services/categoriasApi";

import "../CSS/EditarCliente.css";

function CrearTiendaPage() {

    const navigate = useNavigate();

    const [categorias, setCategorias] = useState([]);

    const [tienda, setTienda] = useState({
        nombre: "",
        email: "",
        telefono: "",
        direccion: "",
        descripcion: "",
        categoria: "",
        imagen: ""
    });

    useEffect(() => {

        const cargarCategorias = async () => {

            try {

                const data = await getCategorias();

                setCategorias(data);

            } catch (error) {

                console.error(error);

            }

        };

        cargarCategorias();

    }, []);

    const guardar = async (e) => {

        e.preventDefault();

        try {

            await createTienda(tienda);

            alert("Tienda creada correctamente");

            navigate("/tiendas/general");

        } catch (error) {

            console.error(error);

            alert("Error al crear tienda");

        }

    };

    return (
        <>
            <HomePageComponent />

            <div className="editar-container">

                <div className="editar-card">

                    <h1>Crear Tienda</h1>

                    <form
                        onSubmit={guardar}
                        className="edicion"
                    >

                        <div>

                            <label>Nombre</label>

                            <input
                                type="text"
                                value={tienda.nombre}
                                onChange={(e) =>
                                    setTienda({
                                        ...tienda,
                                        nombre: e.target.value
                                    })
                                }
                            />

                        </div>

                        <div>

                            <label>Email</label>

                            <input
                                type="email"
                                value={tienda.email}
                                onChange={(e) =>
                                    setTienda({
                                        ...tienda,
                                        email: e.target.value
                                    })
                                }
                            />

                        </div>

                        <div>

                            <label>Teléfono</label>

                            <input
                                type="text"
                                value={tienda.telefono}
                                onChange={(e) =>
                                    setTienda({
                                        ...tienda,
                                        telefono: e.target.value
                                    })
                                }
                            />

                        </div>

                        <div>

                            <label>Dirección</label>

                            <input
                                type="text"
                                value={tienda.direccion}
                                onChange={(e) =>
                                    setTienda({
                                        ...tienda,
                                        direccion: e.target.value
                                    })
                                }
                            />

                        </div>

                        <div>

                            <label>Descripción</label>

                            <textarea
                                rows="3"
                                value={tienda.descripcion}
                                onChange={(e) =>
                                    setTienda({
                                        ...tienda,
                                        descripcion: e.target.value
                                    })
                                }
                            />

                        </div>

                        <div>

                            <div>

                                <label>Categoría</label>

                                <select
                                    value={tienda.categoriaId}
                                    onChange={(e) =>
                                        setTienda({
                                            ...tienda,
                                            categoriaId: Number(e.target.value)
                                        })
                                    }
                                >

                                    <option value="">
                                        Seleccione una categoría
                                    </option>

                                    {categorias.map(categoria => (

                                        <option
                                            key={categoria.id}
                                            value={categoria.id}
                                        >
                                            {categoria.nombre}
                                        </option>

                                    ))}

                                </select>

                            </div>

                        </div>

                        <div>

                            <label>Imagen (URL)</label>

                            <input
                                type="text"
                                placeholder="https://..."
                                value={tienda.imagen}
                                onChange={(e) =>
                                    setTienda({
                                        ...tienda,
                                        imagen: e.target.value
                                    })
                                }
                            />

                        </div>

                        <button type="submit">

                            Crear tienda

                        </button>

                    </form>

                </div>

            </div>
        </>
    );
}

export default CrearTiendaPage;