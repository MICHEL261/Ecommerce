using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;

namespace VentasBackend.Repositories.Interfaces;

public interface ICategoriasRepository
{
    Task<ActionResponse<IEnumerable<Categoria>>> GetAsync();
    Task<ActionResponse<Categoria>> GetAsync(int id);

}
