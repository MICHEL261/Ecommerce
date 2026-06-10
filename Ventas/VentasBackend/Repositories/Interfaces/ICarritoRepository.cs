using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;

namespace VentasBackend.Repositories.Interfaces;

public interface ICarritoRepository
{
    Task<ActionResponse<IEnumerable<Carrito>>> GetAsync();
    Task<ActionResponse<Carrito>> GetAsync(int id);
    Task<ActionResponse<Carrito>> AgregarProductoAsync(
     int carritoId,
     int productoId,
     int cantidad);
}
