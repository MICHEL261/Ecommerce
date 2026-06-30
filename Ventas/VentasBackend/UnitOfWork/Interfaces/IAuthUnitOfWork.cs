using Ventas.Shared.Entidades;

namespace VentasBackend.UnitOfWork.Interfaces;

public interface IAuthUnitOfWork
{
    Task<Usuario?> LoginAsync(string email, string password);
}
