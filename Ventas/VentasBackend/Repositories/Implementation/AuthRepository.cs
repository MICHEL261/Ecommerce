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

    public async Task<Usuario?> LoginAsync(string email, string password)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Rol)
            .Include(u => u.Cliente)
                .ThenInclude(c => c.Carrito)
            .Include(u => u.Tienda)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (usuario == null)
            return null;

        if (usuario.Password != password)
            return null;

        return usuario;
    }
}
