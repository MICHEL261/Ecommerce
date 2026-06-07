using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

    [ApiController]
[Route("api/[controller]")]
public class CategoriasController : GenericController<Categoria>
{
    private readonly ICategoriasUnitOfWork _CategoriasUnitOfWork;

    public CategoriasController(IGenericUnitOfWork<Categoria> unit, ICategoriasUnitOfWork CategoriasUnitOfWork) : base(unit)
    {
        _CategoriasUnitOfWork = CategoriasUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _CategoriasUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _CategoriasUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }
}

