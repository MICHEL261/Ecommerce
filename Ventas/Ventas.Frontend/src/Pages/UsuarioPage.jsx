import HomePageComponent from "../components/HomePageComponent";
import "../CSS/Usuarios.css";

import {
    FaUser,
    FaShoppingBag,
    FaHeart,
    FaQuestionCircle,
    FaSignOutAlt
} from "react-icons/fa";

function App() {

    const nombre = localStorage.getItem("nombre");
    const apellido = localStorage.getItem("apellido");
    const email = localStorage.getItem("email");
    const telefono = localStorage.getItem("telefono");
    const direccion = localStorage.getItem("direccion");

    const cerrarSesion = () => {
        localStorage.clear();
        window.location.href = "/";
    };

    return (
        <>
            <HomePageComponent />

            <div className="usuario-page">

            
                <div className="usuario-layout">

                    {/* MENU IZQUIERDO */}

                    <aside className="sidebar">

                        <div className="avatar">
                            <FaUser />
                        </div>

                        <h2>{nombre} {apellido}</h2>

                        <button>
                            <FaShoppingBag />
                            Mis pedidos
                        </button>

                        <button>
                            <FaHeart />
                            Favoritos
                        </button>

                        <button>
                            <FaQuestionCircle />
                            Centro de ayuda
                        </button>

                        <button
                            className="logout"
                            onClick={cerrarSesion}
                        >
                            <FaSignOutAlt />
                            Cerrar sesión
                        </button>

                    </aside>

                    {/* PERFIL */}

                    <section className="perfil-card">

                        <h2>Mi Perfil</h2>

                        <div className="perfil-grid">

                            <div className="campo">
                                <label>Nombre</label>
                                <input value={nombre} readOnly />
                            </div>

                            <div className="campo">
                                <label>Apellido</label>
                                <input value={apellido} readOnly />
                            </div>

                            <div className="campo">
                                <label>Correo</label>
                                <input value={email} readOnly />
                            </div>

                            <div className="campo">
                                <label>Teléfono</label>
                                <input value={telefono} readOnly />
                            </div>

                            <div className="campo campo-grande">
                                <label>Dirección</label>
                                <input value={direccion} readOnly />
                            </div>

                        </div>

                        <div className="acciones">

                            <button className="guardar">
                                Editar Perfil
                            </button>

                        </div>

                    </section>

                </div>

            </div>

        </>
    );
}

export default App;