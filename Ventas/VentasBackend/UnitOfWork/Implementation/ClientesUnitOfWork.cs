using Microsoft.AspNetCore.Identity;
using Ventas.Shared.DTO;
using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Repositories.Interfaces;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.UnitOfWork.Implementation;

public class ClientesUnitOfWork:GenericUnitOfWork<Cliente>, IClientesUnitOfWork
{
    private readonly IClientesRepository _repository;
    public ClientesUnitOfWork(IGenericRepository<Cliente> repository, IClientesRepository repositorio) : base(repository)
    {
        _repository = repositorio;
    }

    public override async Task<ActionResponse<IEnumerable<Cliente>>> GetAsync() => await _repository.GetAsync();

    public override async Task<ActionResponse<Cliente>> GetAsync(int id) => await _repository.GetAsync(id);
    public override async Task<ActionResponse<Cliente>> AddAsync(Cliente entity) => await _repository.AddAsync(entity);
    public async Task<SignInResult> LoginAsync(LoginDTO model) => await _repository.LoginAsync(model);

    public async Task LogoutAsync() => await _repository.LogoutAsync();

}
