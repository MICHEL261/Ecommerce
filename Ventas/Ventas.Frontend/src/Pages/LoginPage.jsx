import { useState } from "react";
import HomePageComponent from "../components/HomePageComponent";
import "../CSS/Login.css";

function LoginPage() {
    const [moverPanel, setMoverPanel] = useState(false);

    return (
        <>
            <HomePageComponent />

            <div className="container1">
                {/* LOGIN */}
                <div className="form-container login-container">
                    <form>
                        <h1>Login</h1>
                        <input type="text" placeholder="Usuario" />
                        <input type="password" placeholder="Contraseña" />
                        <button type="submit">Ingresar</button>
                    </form>
                </div>

                {/* REGISTRO */}
                <div className="form-container register-container">
                    <form>
                        <h1>Registro</h1>
                        <input type="text" placeholder="Nombre" />
                        <input type="email" placeholder="Correo" />
                        <input type="password" placeholder="Contraseña" />
                        <button type="submit">Registrarse</button>
                    </form>
                </div>

                {/* PANEL MORADO */}
                <div
                    className={`overlay-container ${moverPanel ? "mover" : ""
                        }`}
                >
                    <div className="overlay">
                        <div className="overlay-panel overlay-left">
                            <h1>¡Bienvenida!</h1>
                            <p>¿Ya tienes cuenta?</p>

                            <button
                                type="button"
                                onClick={() => setMoverPanel(true)}
                            >
                                Acceso
                            </button>
                        </div>

                        <div className="overlay-panel overlay-right">
                            <h1>Hola!</h1>
                            <p>Crea tu cuenta para comenzar</p>

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