
import HomePageComponent from "../components/HomePageComponent";
import "../CSS/Usuarios.css";


function App() {


   
    const nombre = localStorage.getItem("nombre");
    const Apellido = localStorage.getItem("apellido");
    const email = localStorage.getItem("email");
    const telefono = localStorage.getItem("telefono");
    const direccion = localStorage.getItem("direccion");
    const cerrarSesion = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("clienteId");
        localStorage.removeItem("nombre");
        localStorage.removeItem("carritoId");

        window.location.href = "/";
    };

    return (
        <>
            <HomePageComponent />
            <div className="general">
                <div className="titulo5">
                    <h1 style={{ color: "white" }}>Bienvenido, {nombre}!</h1>
                </div>

            <div className="usuario-container">
               
              
                <div className="izquierda">
                <button className="btn-Usuarios" onClick={cerrarSesion}>
                Desloguearse
                </button>
                <button className="btn-Usuarios" onClick={cerrarSesion}>
                   Mis pedidos
                        </button>
                        <button className="btn-Usuarios" onClick={cerrarSesion}>
                            Centro de ayudas
                        </button>
                        <button className="btn-Usuarios" onClick={cerrarSesion}>
                           Favoritos
                        </button>
                </div>
                    <div className="derecha">
                        <div className="perfil-container">
                            <h2>Mi perfil</h2>

                            <div className="perfil-grid">
                                <div className="campo">
                                    <label>Nombre</label>
                                    <input type="text" value={nombre}  />
                                </div>

                                <div className="campo">
                                    <label>Apellido</label>
                                    <input type="text" value={Apellido}  />
                                </div>

                                <div className="campo">
                                    <label>Email</label>
                                    <input type="email" value={email}  />
                                </div>

                                <div className="campo">
                                    <label>Teléfono</label>
                                    <input type="text" value={telefono} />
                                </div>

                                <div className="campo">
                                    <label>Dirección</label>
                                    <input type="text" value={direccion}  />
                                </div>
                            </div>

                            <div className="acciones">
                                <button className="guardar">Guardar cambios</button>
                                <button className="cancelar">Cancelar</button>
                            </div>
                      

                        </div>
                    </div>
            
                </div>
            </div>
        </>
    );
}

export default App;
