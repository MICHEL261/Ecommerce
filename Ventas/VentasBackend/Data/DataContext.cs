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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
}
