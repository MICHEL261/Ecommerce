using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;
using VentasBackend.Repositories.Interfaces;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.UnitOfWork.Implementation
{

    public class CarritosUnitOfWork:GenericUnitOfWork<Carrito>, ICarritoUnitOfWork
    {
        private readonly ICarritoRepository _repository;
        public CarritosUnitOfWork(IGenericRepository<Carrito> repository, ICarritoRepository repositorio) : base(repository)
        {
            _repository = repositorio;
        }

        public Task<ActionResponse<Carrito>> AgregarProductoAsync(int carritoId, int productoId, int cantidad)
        {
   
            return _repository.AgregarProductoAsync(carritoId, productoId, cantidad);   
        }

        public override async Task<ActionResponse<IEnumerable<Carrito>>> GetAsync() => await _repository.GetAsync();

        public override async Task<ActionResponse<Carrito>> GetAsync(int id) => await _repository.GetAsync(id);
    }
}
