import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "./pages/HomePage";
import ClientesPage from "./pages/ClientesPage";
import TiendasPage from "./pages/TiendasPage";
import LoginPage from "./pages/LoginPage";
import UsuarioPage from "./pages/UsuarioPage";
import CarritoPage from "./pages/CarritoPage";
import EditarClientePage from "./Pages/EditarClientePage";

import DetalleTiendaPage from "./pages/DetalleTiendaPage";

function App() {

    return (
        <BrowserRouter>

            <Routes>

                <Route path="/" element={<HomePage />} />

                <Route path="/clientes" element={<ClientesPage />} />

                <Route path="/tiendas" element={<TiendasPage />} />

                <Route path="/tienda/:id" element={<DetalleTiendaPage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/carrito" element={<CarritoPage />} />
                <Route path="/usuario" element={<UsuarioPage/>} />
                <Route path="/clientes/editar/:id" element={<EditarClientePage />} />

            </Routes>

        </BrowserRouter>
    );
}

export default App;