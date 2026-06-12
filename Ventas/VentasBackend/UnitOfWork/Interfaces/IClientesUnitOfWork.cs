using Microsoft.AspNetCore.Identity;
using Ventas.Shared.DTO;
using Ventas.Shared.Entidades;
using Ventas.Shared.Responses;

namespace VentasBackend.UnitOfWork.Interfaces;

public interface IClientesUnitOfWork
{
    Task<ActionResponse<IEnumerable<Cliente>>> GetAsync();
    Task<ActionResponse<Cliente>> GetAsync(int id);
    Task<ActionResponse<Cliente>> AddAsync(Cliente entity);

    
}
