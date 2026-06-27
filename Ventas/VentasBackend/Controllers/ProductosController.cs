using Microsoft.AspNetCore.Mvc;
using Ventas.Shared.Entidades;
using VentasBackend.UnitOfWork.Interfaces;

namespace VentasBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController:GenericController<Producto>
{
    public ProductosController(IGenericUnitOfWork<Producto> unit) : base(unit)
    {
    }
}
