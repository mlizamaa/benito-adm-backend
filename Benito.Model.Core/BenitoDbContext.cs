using Benito.Model.Entities.Despensa;
using Benito.Model.Entities.IOT;
using Benito.Model.Entities.ECommerce;
using Benito.Model.Entities.Huerto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
public class BenitoDbContext : DbContext
{       
    //entities
    public DbSet<ItemDespensa> Items { get; set; }
    public DbSet<Actuador> Actuador { get; set; }
    public DbSet<Sensor> Sensor { get; set; }
    public DbSet<Plantacion> Plantacion { get; set; }
    public DbSet<Huerto> Huerto { get; set; }
    public DbSet<Inventario> Inventario { get; set; }
    public DbSet<ItemVenta> ItemVenta { get; set; }
    public DbSet<Benito.Model.Entities.ECommerce.Producto> Producto { get; set; }
    public DbSet<InventarioBodega> InventarioBodega { get; set; }
    public DbSet<StockVenta> StockVenta { get; set; }

    

    public BenitoDbContext(): base()
    {
    }
    public BenitoDbContext(DbContextOptions<BenitoDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=173.248.151.67,1533; Database=template-demo; User ID=mlizama; Password=Marcelo1597; Encrypt=False; MultipleActiveResultSets=True; TrustServerCertificate=True");
    }
} 