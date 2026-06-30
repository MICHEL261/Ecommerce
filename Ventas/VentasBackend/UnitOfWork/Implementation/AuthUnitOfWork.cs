using Ventas.Shared.Entidades;
using VentasBackend.Repositories.Interfaces;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.UnitOfWork.Implementation;

public class AuthUnitOfWork : IAuthUnitOfWork
{
    private readonly IAuthRepository _repository;

    public AuthUnitOfWork(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<Usuario?> LoginAsync(string email, string password)
    {
        return await _repository.LoginAsync(email, password);
    }
}