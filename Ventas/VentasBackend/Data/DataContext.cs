using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Ventas.Shared.Entidades;

namespace VentasBackend.Data;

public class DataContext :DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Tienda> Tiendas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Orden> Ordenes { get; set; }
    public DbSet<OrdenProducto> OrdenesProductos { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ItemCarrito> ItemCarritos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemCarrito>()
            .HasOne(i => i.Producto)
            .WithMany()
            .HasForeignKey(i => i.ProductoId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<OrdenProducto>()
            .HasOne(op => op.Producto)
            .WithMany(p => p.OrdenesProductos)
            .HasForeignKey(op => op.ProductoId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<OrdenProducto>()
            .HasOne(op => op.Ordenes)
            .WithMany(o => o.OrdenesProductos)
            .HasForeignKey(op => op.OrdenId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

}
