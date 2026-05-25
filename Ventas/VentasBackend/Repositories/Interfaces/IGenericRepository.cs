using Ventas.Shared.Responses;

namespace VentasBackend.Repositories.Interfaces;

public interface IGenericRepository<T>where T:class
{
    Task<ActionResponse<T>> GetAsync(int id);
    Task<ActionResponse<T>> AddAsync(T entity);
    Task<ActionResponse<T>> UpdateAsync(T entity);
    Task<ActionResponse<IEnumerable<T>>> GetAsync();
    Task<ActionResponse<T>> DeleteAsync(int id);
}
