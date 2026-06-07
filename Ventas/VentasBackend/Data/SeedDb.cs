using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;

namespace VentasBackend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCategoriasAsync();
        await CheckTiendasAsync();
        

    }
    private async Task CheckCategoriasAsync()
    {
        if (!_context.Categorias.Any())
        {
            _context.Categorias.Add(new Categoria { Nombre = "Restaurantes" });
            _context.Categorias.Add(new Categoria { Nombre = "Cafeterias/Pasteleria" });
            _context.Categorias.Add(new Categoria { Nombre = "Supermercados" });
            _context.Categorias.Add(new Categoria { Nombre = "Farmacias" });
        }
        

        await _context.SaveChangesAsync();
    }

    private async Task CheckTiendasAsync()
    {
        if (!_context.Tiendas.Any())
        {
            _context.Tiendas.Add(new Tienda { Nombre = "El corral", Email = "elcorral@example.com", Telefono = "555-1234" ,Direccion="Calle 123", Imagen= "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/b0/14/94/el-corral.jpg?w=900&h=-1&s=1"
            , CategoriaId = 1 });
            _context.Tiendas.Add(new Tienda {
                Nombre = "Dunkin",
                Email = "Dunkin@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://photos.prnewswire.com/prnfull/20110224/NY53806LOGO?max=200"
            ,
                CategoriaId = 2, 
            });

            _context.Tiendas.Add(new Tienda
            {
                Nombre = "Pasteur",
                Email = "Pasteur@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://arkadiacentrocomercial.com/wp-content/uploads/2021/09/pasteur-drogueria.jpg"
            ,
                CategoriaId = 4
            });

            _context.Tiendas.Add(new Tienda
            {
                Nombre = "Surtimax",
                Email = "Surtimax@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSrwlsDZ9lGEjHyhVKipZNUWpq4DmgSjABZQ&s"
            ,
                CategoriaId = 3
            });
        }

        await _context.SaveChangesAsync();
    }

   
}


