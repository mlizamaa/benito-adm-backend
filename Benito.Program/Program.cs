
using Microsoft.Extensions.DependencyInjection;
using System;
using Benito.Negocio;
using Benito.Datos.Repositorio;
using Benito.Datos.Modelo;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration); // <-- Esto registra la configuración

            services.AddTransient<IInventarioManager, InventarioManager>();
            services.AddTransient<InventarioRepository, InventarioRepository>();
            services.AddTransient<IRepository<Producto>, ProductoRepository>();

            // Crear un nuevo Service Provider
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Obtener una instancia de tu servicio a través del Service Provider
                var inventarioRepository = serviceProvider.GetRequiredService<InventarioRepository>();
                IInventarioManager inventarioManager = serviceProvider.GetRequiredService<IInventarioManager>();
                
                // Utilizar tu servicio
                inventarioManager.AgregarStockBodega(1,100);
                var stockInventario = inventarioManager.ObtenerStockBodega(2);
                //Console.WriteLine(stockInventario.ProductoId);
            }

        }
    }

   

 
}
