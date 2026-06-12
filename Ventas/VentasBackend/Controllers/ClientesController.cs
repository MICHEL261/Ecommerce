using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Implementation;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : GenericController<Cliente>
{

    private readonly IClientesUnitOfWork _clientesUnitOfWork;

    public ClientesController(IGenericUnitOfWork<Cliente> unit, IClientesUnitOfWork cclientesUnitOfWork) : base(unit)
    {
        _clientesUnitOfWork = cclientesUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _clientesUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _clientesUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

    [HttpPut]
    public virtual async Task<IActionResult> PutAsync(Cliente model)
    {
        var action = await _clientesUnitOfWork.AddAsync(model);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }
}

