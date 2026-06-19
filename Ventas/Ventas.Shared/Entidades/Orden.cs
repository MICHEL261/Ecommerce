using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class Orden
{
    public int Id { get; set; }
    public int ClienteId { get; set; }//muchos
    public DateTime Fecha { get; set; }

    public Cliente? Cliente { get; set; } //muchos
    public ICollection<OrdenProducto>? OrdenesProductos { get; set; }
    
    public double Total {  get; set; }
}
