using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;

namespace VentasBackend.UnitOfWork.Interfaces;

public interface ICategoriasUnitOfWork
{
    Task<ActionResponse<IEnumerable<Categoria>>> GetAsync();
    Task<ActionResponse<Categoria>> GetAsync(int id);

}
