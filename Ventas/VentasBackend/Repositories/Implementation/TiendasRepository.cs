using Microsoft.EntityFrameworkCore;
using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Data;
using VentasBackend.Repositories.Interfaces;

namespace VentasBackend.Repositories.Implementation;

public class TiendasRepository : GenericRepository<Tienda>, ITiendasRepository
{
    private readonly DataContext _context;
    public TiendasRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Tienda>>> GetAsync()
    {
        var Tiendas = await _context.Tiendas.Include(c => c.Productos).ToListAsync();
        return new ActionResponse<IEnumerable<Tienda>>
        {
            WasSuccess = true,
            Result = Tiendas
        };
    }

    public override async Task<ActionResponse<Tienda>> GetAsync(int id)
    {
        var Tienda = await _context.Tiendas
             .Include(c => c.Productos)
             .FirstOrDefaultAsync(c => c.Id == id);

        if (Tienda == null)
        {
            return new ActionResponse<Tienda>
            {
                WasSuccess = false,
                Message = "Tienda no existe"
            };
        }

        return new ActionResponse<Tienda>
        {
            WasSuccess = true,
            Result = Tienda
        };
    }


}
