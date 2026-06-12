using Ventas.Shared.Entidades;

namespace VentasBackend.UnitOfWork.Interfaces;

public interface IAuthUnitOfWork
{
    Task<Cliente?> LoginAsync(string email, string password);
}
