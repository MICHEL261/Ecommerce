using Ventas.Shared.Entidades;

namespace VentasBackend.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<Usuario?> LoginAsync(string email, string password);
}
