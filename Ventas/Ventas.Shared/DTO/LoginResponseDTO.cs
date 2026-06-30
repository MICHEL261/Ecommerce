using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.DTO;

public class LoginResponseDTO
{
    public string Token { get; set; }

    public int UsuarioId { get; set; }

    public string Rol { get; set; }

    public int? ClienteId { get; set; }

    public int? TiendaId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }
}