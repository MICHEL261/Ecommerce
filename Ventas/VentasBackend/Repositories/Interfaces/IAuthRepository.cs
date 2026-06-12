using Ventas.Shared.Entidades;

namespace VentasBackend.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<Cliente?> LoginAsync(string email, string password);
}
