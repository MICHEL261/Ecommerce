using Microsoft.EntityFrameworkCore;
using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Data;
using VentasBackend.Repositories.Interfaces;

namespace VentasBackend.Repositories.Implementation;


public class CarritoRepository : GenericRepository<Carrito>, ICarritoRepository
{
    private readonly DataContext _context;
    public CarritoRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Carrito>>> GetAsync()
    {
        var Carritos = await _context.Carritos.Include(c => c.Items).ThenInclude(c => c.Producto).ToListAsync();
        return new ActionResponse<IEnumerable<Carrito>>
        {
            WasSuccess = true,
            Result = Carritos
        };
    }

    public override async Task<ActionResponse<Carrito>> GetAsync(int id)
    {
        var Carrito = await _context.Carritos.Include(c => c.Items).ThenInclude(c => c.Producto)
             .FirstOrDefaultAsync(c => c.Id == id);

        if (Carrito == null)
        {
            return new ActionResponse<Carrito>
            {
                WasSuccess = false,
                Message = "Carrito no existe"
            };
        }

        return new ActionResponse<Carrito>
        {
            WasSuccess = true,
            Result = Carrito
        };
    }

    public async Task<ActionResponse<Carrito>> AgregarProductoAsync(
    int carritoId,
    int productoId,
    int cantidad)
    {
        var carrito = await _context.Carritos
            .Include(c => c.Items)
            .ThenInclude(i => i.Producto)
            .FirstOrDefaultAsync(c => c.Id == carritoId);

        if (carrito == null)
        {
            return new ActionResponse<Carrito>
            {
                WasSuccess = false,
                Message = "Carrito no existe"
            };
        }

        var itemExistente = carrito.Items
            .FirstOrDefault(i => i.ProductoId == productoId);

        if (itemExistente != null)
        {
            itemExistente.Cantidad += cantidad;
        }
        else
        {
            var item = new ItemCarrito
            {
                CarritoId = carritoId,
                ProductoId = productoId,
                Cantidad = cantidad
            };

            carrito.Items.Add(item);
        }

        try
        {
            await _context.SaveChangesAsync();

            return new ActionResponse<Carrito>
            {
                WasSuccess = true,
                Result = carrito
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Carrito>
            {
                WasSuccess = false,
                Message = $"Error al agregar producto: {ex.Message}"
            };
        }
    }
}
