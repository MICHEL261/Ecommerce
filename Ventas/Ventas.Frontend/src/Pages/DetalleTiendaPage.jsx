import { useParams } from "react-router-dom";
import HomePageComponent from "../components/HomePageComponent";

function DetalleTiendaPage() {
    const { id } = useParams();

    return (
        <>
            <HomePageComponent />

            <div>
                <h1>Tienda {id}</h1>
            </div>
        </>
    );
}

export default DetalleTiendaPage;