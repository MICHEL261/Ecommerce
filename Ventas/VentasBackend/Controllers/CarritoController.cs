using Microsoft.AspNetCore.Mvc;
using Ventas.Shared.DTO;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarritoController : GenericController<Carrito>
{
    private readonly ICarritoUnitOfWork _CarritoUnitOfWork;
    public CarritoController(IGenericUnitOfWork<Carrito> unit, ICarritoUnitOfWork carritoUnitOfWork)
        : base(unit)
    {
        _CarritoUnitOfWork = carritoUnitOfWork;
    }


    [HttpPost("{carritoId}/productos")]
    public async Task<IActionResult> AgregarProducto(
    int carritoId,
    [FromBody] AgregarProductoDTO model)
    {
        var response = await _CarritoUnitOfWork.AgregarProductoAsync(
            carritoId,
            model.ProductoId,
            model.Cantidad);

        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }

        return BadRequest(response.Message);
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _CarritoUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _CarritoUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }
    [HttpPut("item/{itemId}")]
    public async Task<IActionResult> ActualizarCantidad(
    int itemId,
    [FromBody] ActualizarCantidadDTO model)
    {
        var response =
            await _CarritoUnitOfWork.ActualizarCantidadAsync(
                itemId,
                model.Cantidad);

        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }

        return BadRequest(response.Message);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> CrearOrden(
    [FromBody] CrearOrdenDTO model)
    {
        var response =
            await _CarritoUnitOfWork.CrearOrdenAsync(
                model.ClienteId);

        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }

        return BadRequest(response.Message);
    }


    [HttpDelete("item/{itemId}/carrito/{carritoId}")]
    public async Task<IActionResult> EliminarProducto(
        int itemId,
        int carritoId)
    {
        var response = await _CarritoUnitOfWork.EliminarProductoAsync(itemId, carritoId);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest(response.Message);
    }
}
