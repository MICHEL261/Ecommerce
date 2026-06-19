
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
            <h1>Bienvenido, {nombre}!</h1>
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
                        <h2>Mi perfil</h2>
                        <div className="perfil">
                        <p className="Tarjeta"><strong>Nombre:</strong> {nombre}</p>
                        <p className="Tarjeta"><strong>Apellido:</strong> {Apellido}</p>
                        <p className="Tarjeta"><strong>Email:</strong> {email}</p>
                        <p className="Tarjeta"><strong>Teléfono:</strong> {telefono}</p>
                            <p className="Tarjeta"><strong>Dirección:</strong> {direccion}</p>
                        </div>
                    </div>
            
                </div>
            </div>
        </>
    );
}

export default App;
