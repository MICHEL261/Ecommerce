using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;

namespace VentasBackend.UnitOfWork.Interfaces;

public interface ITiendasUnitOfWork
{
    Task<ActionResponse<IEnumerable<Tienda>>> GetAsync();
    Task<ActionResponse<Tienda>> GetAsync(int id);
}
