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
        await CheckProductosAsync();

        await CheckClientesAsync();
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
    private async Task CheckClientesAsync()
    {
        if (!_context.Clientes.Any())
        {
            _context.Clientes.Add(new Cliente { Nombre = "Juan", Apellido = "Pérez", Email = "juan.perez@example.com", Telefono = "555-1234" , Direccion = "Calle 123" });
            _context.Clientes.Add(new Cliente { Nombre = "María", Apellido = "García", Email = "maria.garcia@example.com", Telefono = "555-5678" , Direccion = "Calle 456" });
        }


        await _context.SaveChangesAsync();
    }

    private async Task CheckTiendasAsync()
    {
        if (!_context.Tiendas.Any())
        {
            _context.Tiendas.Add(new Tienda
            {
                Nombre = "El corral",
                Email = "elcorral@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/b0/14/94/el-corral.jpg?w=900&h=-1&s=1",
                Descripcion = "Hamburguesas, papas, gaseosas"
            ,
                CategoriaId = 1
            });
            _context.Tiendas.Add(new Tienda
            {
                Nombre = "Dunkin",
                Email = "Dunkin@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://photos.prnewswire.com/prnfull/20110224/NY53806LOGO?max=200"
            ,
                CategoriaId = 2,
                Descripcion = "Donas, cafe, pasteles"
            });

            _context.Tiendas.Add(new Tienda
            {
                Nombre = "Pasteur",
                Email = "Pasteur@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://arkadiacentrocomercial.com/wp-content/uploads/2021/09/pasteur-drogueria.jpg"
            ,
                CategoriaId = 4,
                Descripcion = "Medicamentos, productos de cuidado personal"
            });

            _context.Tiendas.Add(new Tienda
            {
                Nombre = "Surtimax",
                Email = "Surtimax@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSrwlsDZ9lGEjHyhVKipZNUWpq4DmgSjABZQ&s"
            ,
                Descripcion = "Alimentos, productos de limpieza, artículos para el hogar",
                CategoriaId = 3
            });
            _context.Tiendas.Add(new Tienda
            {
                Nombre = "Creeps And Waffles",
                Email = "Dunkin@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://images.squarespace-cdn.com/content/v1/6049e33a3512a120620cfe14/1633010113498-F2D3X5PBBMB5IF0F7E9F/01_C%26W_Logo_Moneda_Ag_2020.png"
            ,
                Descripcion = "Waffles, crepes, café",
                CategoriaId = 1,
            });
            _context.Tiendas.Add(new Tienda
            {
                Nombre = "Los verdes",
                Email = "losverdes@example.com",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQv7RDJCfO1a4ke8SQOdrGZpBko4s0cA3gCx9lEB3gw7hZTI8R0nhXtrCw-&s=10"
            ,
                Descripcion = "Ensaladas, jugos naturales, wraps",
                CategoriaId = 1,
            });
        }

        await _context.SaveChangesAsync();
    }
    private async Task CheckProductosAsync()
    {
        if (!_context.Productos.Any())
        {
            _context.Productos.Add(new Producto
            {
                Nombre = "Combo hamburguesa clasica",
                Descripcion = "hamburguesa, papas, gaseosa",
                Precio = 10.99,
                Imagen = "https://d7364jmfys2bj.cloudfront.net/products/5244a4b4-030a-4984-9c6e-572e6bc784e0_1765376957470.jpg",
                TiendaId = 1
            });
            _context.Productos.Add(new Producto
            {
                Nombre = "Combo perro clasico",
                Descripcion = "perro, papas, gaseosa",
                Precio = 90,
                Imagen = "https://d7364jmfys2bj.cloudfront.net/products/51af59ba-ed2f-44b9-b89c-3e3f3108c0a9_1773761150274.jpg",
                TiendaId = 1
            });
            _context.Productos.Add(new Producto
            {
                Nombre = "aros de cebolla",
                Descripcion = "15 aros",
                Precio = 90,
                Imagen = "https://d7364jmfys2bj.cloudfront.net/products/43.3.433349/07c2220a-f2c2-4574-b545-52f9c2c79fc2.webp",
                TiendaId = 1
            });
            _context.Productos.Add(new Producto
            {
                Nombre = "Donas veganas",
                Descripcion = "Combo con cafe negro",
                Precio = 2.99,
                Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQN-uVBhHc-uRODF4yLenIGSsd3ZVXKpegiSJcH7dsq6k0Gvs4Os6s39z4&s=10",
                TiendaId = 2
            });
        }

        await _context.SaveChangesAsync();
    }

}

