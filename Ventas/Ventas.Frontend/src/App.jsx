import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "./pages/HomePage";
import ClientesPage from "./pages/ClientesPage";
import TiendasPage from "./pages/TiendasPage";

function App() {

    return (
        <BrowserRouter>

            <Routes>

                <Route path="/" element={<HomePage />} />

                <Route path="/clientes" element={<ClientesPage />} />

                <Route path="/tiendas" element={<TiendasPage />} />

            </Routes>

        </BrowserRouter>
    );
}

export default App;