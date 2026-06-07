using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Tienda>? Tiendas { get; set; }//uno
}
