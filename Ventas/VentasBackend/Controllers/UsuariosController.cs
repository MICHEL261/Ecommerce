using Microsoft.AspNetCore.Mvc;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController:GenericController<Usuario>
{
    public UsuariosController(IGenericUnitOfWork<Usuario> unit) : base(unit)
    {
    }
}
