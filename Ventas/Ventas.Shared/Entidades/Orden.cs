using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class Orden
{
    public string Id { get; set; }
    public int ClienteId { get; set; }//muchos

    public Cliente? Cliente { get; set; } //muchos
    public ICollection<OrdenProducto>? OrdenesProductos { get; set; }
}
