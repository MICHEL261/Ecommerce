import { useState } from "react";
import { useNavigate } from "react-router-dom";
import HomePageComponent from "../components/HomePageComponent";
import "../CSS/Login.css";
import { login } from "../services/authApi";

function LoginPage() {
    const [moverPanel, setMoverPanel] = useState(false);

    const navigate = useNavigate();


    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
 

    const iniciarSesion = async (e) => {
        e.preventDefault();

        try {
            const data = await login(email, password);

            localStorage.setItem("token", data.token);
            localStorage.setItem("usuarioId", data.usuarioId);
            localStorage.setItem("rol", data.rol);

            if (data.clienteId) {
                localStorage.setItem("clienteId", data.clienteId);
                localStorage.setItem("carritoId", data.carritoId);
                localStorage.setItem("apellido", data.apellido);
                localStorage.setItem("telefono", data.telefono);
                localStorage.setItem("direccion", data.direccion);
            }

            if (data.tiendaId) {
                localStorage.setItem("tiendaId", data.tiendaId);
            }

            localStorage.setItem("nombre", data.nombre);
            localStorage.setItem("email", data.email);

            alert(`Bienvenido ${data.nombre}`);

            console.log("LOGIN:", data);

            navigate("/");
        }
        catch (error) {
            console.error(error);
            alert("Correo o contraseña incorrectos");
        }
    };
    return (
        <>
            <HomePageComponent />

            <div className="container1">

                {/* LOGIN */}
                <div className="form-container login-container">
                    <form onSubmit={iniciarSesion}>
                        <h1>Login</h1>

                        <input
                            type="email"
                            placeholder="Correo"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />

                        <input
                            type="password"
                            placeholder="Contraseña"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />

                        <button type="submit">
                            Ingresar
                        </button>
                    </form>
                </div>

                {/* REGISTRO */}
                <div className="form-container register-container">
                    <form>
                        <h1>Registro</h1>

                        <input
                            type="text"
                            placeholder="Nombre"
                        />

                        <input
                            type="email"
                            placeholder="Correo"
                        />

                        <input
                            type="password"
                            placeholder="Contraseña"
                        />

                        <button type="submit">
                            Registrarse
                        </button>
                    </form>
                </div>

                {/* PANEL MORADO */}
                <div
                    className={`overlay-container ${moverPanel ? "mover" : ""
                        }`}
                >
                    <div className="overlay">

                        <div className="overlay-panel overlay-left">
                            <h1>¡Bienvenido!</h1>

                            <p>
                                ¿Ya tienes una cuenta?
                            </p>

                            <button
                                type="button"
                                onClick={() => setMoverPanel(true)}
                            >
                                Acceso
                            </button>
                        </div>

                        <div className="overlay-panel overlay-right">
                            <h1>Hola!</h1>

                            <p>
                                Crea tu cuenta para comenzar
                            </p>

                            <button
                                type="button"
                                onClick={() => setMoverPanel(false)}
                            >
                                Registro
                            </button>
                        </div>

                    </div>
                </div>

            </div>
        </>
    );
}

export default LoginPage;