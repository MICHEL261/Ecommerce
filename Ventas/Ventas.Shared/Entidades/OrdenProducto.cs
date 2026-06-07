using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class OrdenProducto
{
    public int Id { get; set; }
    public int OrdenId { get; set; }//muchos

    public Orden? Ordenes { get; set; } //muchos
    public ICollection<Producto>? Productos { get; set; } //uno
}
