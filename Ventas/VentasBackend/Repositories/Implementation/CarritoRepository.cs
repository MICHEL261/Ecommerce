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
    public async Task<ActionResponse<ItemCarrito>> ActualizarCantidadAsync(
    int itemId,
    int cantidad)
    {
        var item = await _context.ItemCarritos
            .FirstOrDefaultAsync(x => x.Id == itemId);

        if (item == null)
        {
            return new ActionResponse<ItemCarrito>
            {
                WasSuccess = false,
                Message = "Item no encontrado"
            };
        }

        item.Cantidad = cantidad;

        await _context.SaveChangesAsync();

        return new ActionResponse<ItemCarrito>
        {
            WasSuccess = true,
            Result = item
        };
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

    public async Task<ActionResponse<Carrito>> EliminarProductoAsync(int itemId, int carritoId)
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

        var item = carrito.Items.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return new ActionResponse<Carrito>
            {
                WasSuccess = false,
                Message = "Item no encontrado"
            };
        }

        carrito.Items.Remove(item);

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
                Message = $"Error al eliminar producto: {ex.Message}"
            };
        }
    }

    public async Task<ActionResponse<Orden>> CrearOrdenAsync(int clienteId)
    {
        var carrito = await _context.Carritos
        .Include(c => c.Items)
        .ThenInclude(i => i.Producto)
        .FirstOrDefaultAsync(c => c.ClienteId == clienteId);

        if (carrito == null)
        {
            return new ActionResponse<Orden>
            {
                WasSuccess = false,
                Message = "Carrito no encontrado"
            };
        }

        if (!carrito.Items.Any())
        {
            return new ActionResponse<Orden>
            {
                WasSuccess = false,
                Message = "El carrito está vacío"
            };
        }


        var orden = new Orden
        {
            ClienteId = clienteId,
            Fecha = DateTime.Now,
            Total = carrito.Items.Sum(x =>
       x.Cantidad * x.Producto.Precio)

        };

        _context.Ordenes.Add(orden);
        await _context.SaveChangesAsync();

        var ordenProductos = carrito.Items.Select(i => new OrdenProducto
        {
            OrdenId = orden.Id,
            ProductoId = i.ProductoId,
            Cantidad = i.Cantidad,
            Precio = i.Producto.Precio
        }).ToList();
        _context.OrdenesProductos.AddRange(ordenProductos);
        await _context.SaveChangesAsync();

        return new ActionResponse<Orden>
        {
            WasSuccess = true,
            Result = orden
        };
    }
}
