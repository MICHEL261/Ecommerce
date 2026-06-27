function Formulario({ campos, valores, setValores, onSubmit, titulo }) {
    return (
        <div className="editar-container">
            <form className="edicion" onSubmit={onSubmit}>
                <h1>{titulo}</h1>

                {campos.map(campo => (
                    <div key={campo.name}>
                        <label>{campo.label}</label>

                        <input
                            type={campo.type}
                            value={valores[campo.name] || ""}
                            onChange={(e) =>
                                setValores({
                                    ...valores,
                                    [campo.name]: e.target.value
                                })
                            }
                        />
                    </div>
                ))}

                <button type="submit">
                    Guardar cambios
                </button>
            </form>
        </div>
    );
}