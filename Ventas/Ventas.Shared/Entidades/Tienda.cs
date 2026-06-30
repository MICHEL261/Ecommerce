using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Shared.Entidades;

public class Tienda
{
    public int Id { get; set; }
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
   
    public string Telefono { get; set; }
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
    public string Direccion { get; set; }
    [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
    public ICollection<Producto>? Productos { get; set; }//uno

    public int CategoriaId { get; set; }//muchos

    public Categoria? Categorias { get; set; } //muchos
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; }
}
