using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ventas.Shared.DTO;
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
        var Clientes = await _context.Clientes.Include(c => c.Ordenes).Include(c=> c.Usuario).ThenInclude(c=>c.Rol).Include(c => c.Carrito).ThenInclude(c => c.Items).ToListAsync();
        return new ActionResponse<IEnumerable<Cliente>>
        {
            WasSuccess = true,
            Result = Clientes
        };
    }

    public override async Task<ActionResponse<Cliente>> GetAsync(int id)
    {
        var Cliente = await _context.Clientes
             .Include(c => c.Ordenes).Include(c => c.Usuario).ThenInclude(c => c.Rol)
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
    public override async Task<ActionResponse<Cliente>> AddAsync(Cliente entity)
    {
        _context.Clientes.Add(entity);

        try
        {
            await _context.SaveChangesAsync();

            var carrito = new Carrito
            {
                ClienteId = entity.Id
            };

            _context.Carritos.Add(carrito);
            await _context.SaveChangesAsync();

            return new ActionResponse<Cliente>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }



    private ActionResponse<Cliente> ExceptionActionResponse(Exception exception)
    {
        return new ActionResponse<Cliente>
        {
            WasSuccess = false,
            Message = exception.Message
        };
    }

    private ActionResponse<Cliente> DbUpdateExceptionActionResponse()
    {
        return new ActionResponse<Cliente  >
        {
            WasSuccess = false,
            Message = "Ya existe el registro que estas intentando crear."
        };
    }
}
