using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class Usuario
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public int RolId { get; set; }

    public Rol Rol { get; set; }

    public Cliente? Cliente { get; set; }

    public Tienda? Tienda { get; set; }
}
