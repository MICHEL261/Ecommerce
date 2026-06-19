using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class ItemCarrito
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
    public int CarritoId { get; set; }=0;
    public Carrito? Carrito { get; set; } = null;
    [NotMapped]
    public double Subtotal =>
       (Producto?.Precio ?? 0) * Cantidad;
}
