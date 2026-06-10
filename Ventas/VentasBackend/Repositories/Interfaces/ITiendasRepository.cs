using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;

namespace VentasBackend.Repositories.Interfaces;

public interface ITiendasRepository
{
    Task<ActionResponse<IEnumerable<Tienda>>> GetAsync();
    Task<ActionResponse<Tienda>> GetAsync(int id);

}
