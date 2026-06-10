using Microsoft.AspNetCore.Mvc;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemCarritoController : GenericController<ItemCarrito>
{
    public ItemCarritoController(IGenericUnitOfWork<ItemCarrito> unit)
        : base(unit)
    {
    }
}