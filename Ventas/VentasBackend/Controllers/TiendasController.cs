using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Implementation;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiendasController : GenericController<Tienda>
{
    private readonly ITiendasUnitOfWork _tiendasUnitOfWork;
    public TiendasController(IGenericUnitOfWork<Tienda> unit, ITiendasUnitOfWork tiendasUnitOfWork  ) : base(unit)
    {
        _tiendasUnitOfWork = tiendasUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _tiendasUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _tiendasUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }
}

