using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Repositories.Interfaces;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.UnitOfWork.Implementation;

public class CategoriasUnitOfWork : GenericUnitOfWork<Categoria>, ICategoriasUnitOfWork
{
    private readonly ICategoriasRepository _repository;
    public CategoriasUnitOfWork(IGenericRepository<Categoria> repository, ICategoriasRepository repositorio) : base(repository)
    {
        _repository = repositorio;
    }

    public override async Task<ActionResponse<IEnumerable<Categoria>>> GetAsync() => await _repository.GetAsync();

    public override async Task<ActionResponse<Categoria>> GetAsync(int id) => await _repository.GetAsync(id);
}


