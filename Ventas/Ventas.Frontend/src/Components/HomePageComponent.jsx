
import { Link } from "react-router-dom";
import "../CSS/Home.css";
import logo from "../assets/Logo.png";


function HomePageComponent() {
    

    return (
        
            <nav className="navbar">
            <Link to="/"><img src={logo} alt="logo" className="logo" /></Link>
                <input className="input" type="text" placeholder="Buscar..." />
                <Link to="/clientes"><button>Ir a Clientes</button></Link>
                <Link to="/productos"><button>Ir a Productos</button></Link>
                <Link to="/tiendas"><button>Ir a Tiendas</button></Link>
                
               
            </nav>
            


           
        
    );
}

export default HomePageComponent;
