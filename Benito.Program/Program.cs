
using Microsoft.Extensions.DependencyInjection;
using System;
using Benito.Negocio;
using Benito.Datos.Repositorio;
using Benito.Datos.Modelo;
using Microsoft.Extensions.Configuration;
using System.IO;
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
            services.AddTransient<IVentaRepository, VentaRepository>();
            services.AddTransient<IInventarioManager, InventarioManager>();
            services.AddTransient<IVentaManager, VentaManager>();
            services.AddTransient<StockInventarioRepository, StockInventarioRepository>();
            services.AddTransient<IRepositorioCrud<Producto>, ProductoRepository>();
            //services.AddTransient<IRepositorioCrud<Producto>, IRepositorioCrud<Producto>>();
            //services.AddTransient<IEntidadManager<Producto>, EntidadManager<Producto>>();
            // Crear un nuevo Service Provider
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // instanciar un repositorio para producto
                var productoRepository = serviceProvider.GetRequiredService<IRepositorioCrud<Producto>>();

                // crear 10 productos con el repositorio
                for(int i = 0; i < 10; i++){
                    productoRepository.Crear(new Producto { 
                    Nombre = "Producto " + i, 
                    CodigoBarra ="",
                    Descripcion = "Producto " + i,
                    Precio = 1000 ,
                    Descuento = 0,
                    McaBorrador = false,
                    Imagen = "Imagen " + i,
                    CodTipo = "CodTipo " + i
                    });
                }


                // listar todos los productos con el repositorio
                // imprimir los productos
                var productos = productoRepository.Listar();
                foreach(var p in productos){
                    Console.WriteLine("id : {0}, nombre : {1} ",p.Id, p.Nombre);
                }
                
                /*
                // Obtener una instancia de tu servicio a través del Service Provider
                var inventarioRepository = serviceProvider.GetRequiredService<StockInventarioRepository>();
                IInventarioManager inventarioManager = serviceProvider.GetRequiredService<IInventarioManager>();
                IVentaManager ventaManager = serviceProvider.GetRequiredService<IVentaManager>();
                // Utilizar tu servicio
                inventarioManager.AgregarInventarioBodega(1,100);
                var stockInventario = inventarioManager.ObtenerInventarioBodega(1);
                inventarioManager.AgregarInventarioBodega(1,-5);
                inventarioManager.AgregarInventarioBodega(1,-3);
                inventarioManager.AgregarInventarioBodega(1,-2);
                inventarioManager.AgregarInventarioBodega(1,-2);
                inventarioManager.AgregarInventarioBodega(1,-2);
                inventarioManager.AgregarInventarioBodega(1,-2);
                inventarioManager.AgregarInventarioBodega(1,-2);
                inventarioManager.AgregarInventarioBodega(1,-2);
                stockInventario = inventarioManager.ObtenerInventarioBodega(1);
                inventarioManager.AgregarInventarioBodega(2,30);
                inventarioManager.AgregarInventarioBodega(2,-3);
                stockInventario = inventarioManager.ObtenerInventarioBodega(1);
                var inventarioBodega = inventarioManager.ListarInventarioBodega();
                foreach(var i in inventarioBodega){
                    Console.WriteLine("producto : {0}, cantidad : {1} ",i.ProductoId, i.Cantidad);
                }

                var venta = ventaManager.Registrar(new List<ItemVenta>(){
                    new ItemVenta { ProductoId = 1, Cantidad = 1, MontoNeto= 1000, MontoBruto = 1190, Iva = 190  },
                    new ItemVenta { ProductoId = 1, Cantidad = 1, MontoNeto= 1000, MontoBruto = 1190, Iva = 190  },
                    new ItemVenta { ProductoId = 1, Cantidad = 1, MontoNeto= 1000, MontoBruto = 1190, Iva = 190  }
                });
                Console.WriteLine(venta.MontoBruto);*/
            }

        }
    }

   

 
}
