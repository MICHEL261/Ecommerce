using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : GenericController<Cliente>
{
    public ClientesController(IGenericUnitOfWork<Cliente> unit) : base(unit)
    {
    }
}

