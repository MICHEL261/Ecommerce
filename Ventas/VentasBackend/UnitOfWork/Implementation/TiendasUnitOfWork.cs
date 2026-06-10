using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Repositories.Interfaces;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.UnitOfWork.Implementation;

public class TiendasUnitOfWork:GenericUnitOfWork<Tienda>, ITiendasUnitOfWork
{
    private readonly ITiendasRepository _repository;
    public TiendasUnitOfWork(IGenericRepository<Tienda> repository, ITiendasRepository repositorio) : base(repository)
    {
        _repository = repositorio;
    }

    public override async Task<ActionResponse<IEnumerable<Tienda>>> GetAsync() => await _repository.GetAsync();

    public override async Task<ActionResponse<Tienda>> GetAsync(int id) => await _repository.GetAsync(id);
}
