using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;

namespace VentasBackend.UnitOfWork.Interfaces;

public interface ICarritoUnitOfWork
{
    Task<ActionResponse<IEnumerable<Carrito>>> GetAsync();
    Task<ActionResponse<Carrito>> GetAsync(int id);
    Task<ActionResponse<ItemCarrito>> ActualizarCantidadAsync(
      int itemId,
      int cantidad);
    Task<ActionResponse<Orden>> CrearOrdenAsync(int clienteId);
    Task<ActionResponse<Carrito>> EliminarProductoAsync(int itemId, int CarritoId);
    Task<ActionResponse<Carrito>> AgregarProductoAsync(
     int carritoId,
     int productoId,
     int cantidad);
}
