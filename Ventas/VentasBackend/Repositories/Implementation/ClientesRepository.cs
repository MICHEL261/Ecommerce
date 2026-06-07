using Microsoft.EntityFrameworkCore;
using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Data;
using VentasBackend.Repositories.Interfaces;

namespace VentasBackend.Repositories.Implementation;

public class ClientesRepository : GenericRepository<Cliente>, IClientesRepository
{
    private readonly DataContext _context;
    public ClientesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Cliente>>> GetAsync()
    {
        var Clientes = await _context.Clientes.Include(c => c.Ordenes).ToListAsync();
        return new ActionResponse<IEnumerable<Cliente>>
        {
            WasSuccess = true,
            Result = Clientes
        };
    }

    public override async Task<ActionResponse<Cliente>> GetAsync(int id)
    {
        var Cliente = await _context.Clientes
             .Include(c => c.Ordenes)
             .FirstOrDefaultAsync(c => c.Id == id);

        if (Cliente == null)
        {
            return new ActionResponse<Cliente>
            {
                WasSuccess = false,
                Message = "Cliente no existe"
            };
        }

        return new ActionResponse<Cliente>
        {
            WasSuccess = true,
            Result = Cliente
        };
    }


}
