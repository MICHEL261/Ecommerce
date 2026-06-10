using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class Carrito
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public List<ItemCarrito> Items { get; set; } = new List<ItemCarrito>();
}
