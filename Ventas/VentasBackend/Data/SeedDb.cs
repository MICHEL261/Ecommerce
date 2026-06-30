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

        await CheckRolesAsync();
        await CheckCategoriasAsync();
        await CheckTiendasAsync();
        await CheckProductosAsync();
        await CheckClientesAsync();
    }
    private async Task CheckRolesAsync()
    {
        if (!_context.Roles.Any())
        {
            _context.Roles.Add(new Rol { Nombre = "Administrador" });
            _context.Roles.Add(new Rol { Nombre = "Cliente" });
            _context.Roles.Add(new Rol { Nombre = "Tienda" });

            await _context.SaveChangesAsync();
        }
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
            var usuario1 = new Usuario
            {
                Email = "michel@gmail.com",
                Password = "1234567",
                RolId = 2 // Cliente
            };

            var usuario2 = new Usuario
            {
                Email = "maria.garcia@example.com",
                Password = "Password123!",
                RolId = 2 // Cliente
            };

            _context.Usuarios.AddRange(usuario1, usuario2);

            await _context.SaveChangesAsync();

            var cliente1 = new Cliente
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Telefono = "555-1234",
                Direccion = "Calle 123",
                UsuarioId = usuario1.Id
            };

            var cliente2 = new Cliente
            {
                Nombre = "María",
                Apellido = "García",
                Telefono = "555-5678",
                Direccion = "Calle 456",
                UsuarioId = usuario2.Id
            };

            _context.Clientes.AddRange(cliente1, cliente2);

            await _context.SaveChangesAsync();

            _context.Carritos.AddRange(
                new Carrito
                {
                    ClienteId = cliente1.Id
                },
                new Carrito
                {
                    ClienteId = cliente2.Id
                });

            await _context.SaveChangesAsync();
        }
    }
    private async Task CheckTiendasAsync()
    {
        if (!_context.Tiendas.Any())
        {
            var usuarioCorral = new Usuario
            {
                Email = "elcorral@example.com",
                Password = "123456",
                RolId = 3
            };

            var usuarioDunkin = new Usuario
            {
                Email = "dunkin@example.com",
                Password = "123456",
                RolId = 3
            };

            var usuarioPasteur = new Usuario
            {
                Email = "pasteur@example.com",
                Password = "123456",
                RolId = 3
            };

            var usuarioSurtimax = new Usuario
            {
                Email = "surtimax@example.com",
                Password = "123456",
                RolId = 3
            };

            var usuarioCrepes = new Usuario
            {
                Email = "crepes@example.com",
                Password = "123456",
                RolId = 3
            };

            var usuarioLosVerdes = new Usuario
            {
                Email = "losverdes@example.com",
                Password = "123456",
                RolId = 3
            };

            _context.Usuarios.AddRange(
                usuarioCorral,
                usuarioDunkin,
                usuarioPasteur,
                usuarioSurtimax,
                usuarioCrepes,
                usuarioLosVerdes);

            await _context.SaveChangesAsync();

            _context.Tiendas.AddRange(

                new Tienda
                {
                    Nombre = "El Corral",
                    Telefono = "555-1234",
                    Direccion = "Calle 123",
                    Imagen = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/b0/14/94/el-corral.jpg?w=900&h=-1&s=1",
                    Descripcion = "Hamburguesas, papas, gaseosas",
                    CategoriaId = 1,
                    UsuarioId = usuarioCorral.Id
                },

                new Tienda
                {
                    Nombre = "Dunkin",
                    Telefono = "555-1234",
                    Direccion = "Calle 123",
                    Imagen = "https://photos.prnewswire.com/prnfull/20110224/NY53806LOGO?max=200",
                    Descripcion = "Donas, café, pasteles",
                    CategoriaId = 2,
                    UsuarioId = usuarioDunkin.Id
                },

                new Tienda
                {
                    Nombre = "Pasteur",
                    Telefono = "555-1234",
                    Direccion = "Calle 123",
                    Imagen = "https://arkadiacentrocomercial.com/wp-content/uploads/2021/09/pasteur-drogueria.jpg",
                    Descripcion = "Medicamentos, productos de cuidado personal",
                    CategoriaId = 4,
                    UsuarioId = usuarioPasteur.Id
                },

                new Tienda
                {
                    Nombre = "Surtimax",
                    Telefono = "555-1234",
                    Direccion = "Calle 123",
                    Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSrwlsDZ9lGEjHyhVKipZNUWpq4DmgSjABZQ&s",
                    Descripcion = "Alimentos, productos de limpieza, artículos para el hogar",
                    CategoriaId = 3,
                    UsuarioId = usuarioSurtimax.Id
                },

                new Tienda
                {
                    Nombre = "Crepes & Waffles",
                    Telefono = "555-1234",
                    Direccion = "Calle 123",
                    Imagen = "https://images.squarespace-cdn.com/content/v1/6049e33a3512a120620cfe14/1633010113498-F2D3X5PBBMB5IF0F7E9F/01_C%26W_Logo_Moneda_Ag_2020.png",
                    Descripcion = "Waffles, crepes, café",
                    CategoriaId = 1,
                    UsuarioId = usuarioCrepes.Id
                },

                new Tienda
                {
                    Nombre = "Los Verdes",
                    Telefono = "555-1234",
                    Direccion = "Calle 123",
                    Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQv7RDJCfO1a4ke8SQOdrGZpBko4s0cA3gCx9lEB3gw7hZTI8R0nhXtrCw-&s=10",
                    Descripcion = "Ensaladas, jugos naturales, wraps",
                    CategoriaId = 1,
                    UsuarioId = usuarioLosVerdes.Id
                }

            );

            await _context.SaveChangesAsync();
        }
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

