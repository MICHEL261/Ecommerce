
import { Link } from "react-router-dom";
import "../CSS/Home.css";


import HomePageComponent from "../components/HomePageComponent";
import breakfast from "../assets/breakfast.png";

function HomePage() {

    
    return (
        <div className="container">
            <>
                <HomePageComponent />
            <section className="seccion">
                <img src={breakfast} alt="Desayuno" className="banner-img" />

                <div className="texto-banner">
                    <h1>Bienvenido a Breakfast</h1>
                    <p>Encuentra tus restaurantes favoritos</p>
                    <Link to="/tiendas">
                    <button className="btn-principal">
                        Explorar tiendas
                        </button>
                    </Link>
                </div>
            </section>

            
          </>
        </div>
    );
}

export default HomePage;
