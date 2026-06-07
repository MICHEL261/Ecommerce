using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class Producto
{

    public int Id { get; set; }
    public int Nombre { get; set; }
    public double Precio { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
    public int TiendaId { get; set; }//muchos

    public Tienda? Tienda { get; set; } //muchos

    public int OrdenProductoId { get; set; }//muchos

    public OrdenProducto? OrdenesProductos { get; set; } //muchos

}
