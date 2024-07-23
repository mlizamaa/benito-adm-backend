using Benito.Model.Entities.Despensa;
using Benito.Model.Entities.IOT;
using Benito.Model.Entities.ECommerce;
using Benito.Model.Entities.Huerto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

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
        // lee el connection string desde el archivo de configuracion appsettings.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("sql"));
        
    }
} 