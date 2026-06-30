using Microsoft.AspNetCore.Mvc;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController:GenericController<Rol>
{
    public RolesController(IGenericUnitOfWork<Rol> unit) : base(unit)
    {
    }
}
