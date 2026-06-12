using Microsoft.EntityFrameworkCore;
using Ventas.Shared.Entidades;
using VentasBackend.Data;
using VentasBackend.Repositories.Interfaces;

namespace VentasBackend.Repositories.Implementation;

public class AuthRepository : IAuthRepository
{
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> LoginAsync(string email, string password)
    {
        return await _context.Clientes
            .Include(x => x.Carrito)
            .FirstOrDefaultAsync(x =>
                x.Email == email &&
                x.Password == password);
    }
}
