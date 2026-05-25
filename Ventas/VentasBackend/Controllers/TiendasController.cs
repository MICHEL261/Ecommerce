using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiendasController : GenericController<Tienda>
{
    public TiendasController(IGenericUnitOfWork<Tienda> unit) : base(unit)
    {
    }
}

