
using System.Runtime.CompilerServices;
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.Modelo;
using Benito.Datos.Repositorio;
using AutoMapper;
namespace Benito.Negocio {

    public interface IInventarioManager
    {
        StockVenta AgregarAtockVenta(int productoId, int cantidad);
        StockInventario AgregarStockBodega(int productoId, int cantidad);
        StockInventario ObtenerStockBodega(int id);
    }

    public class InventarioManager : IInventarioManager
    {
        private readonly InventarioRepository _inventarioRepository;
        private readonly IRepository<Producto> _productoRepository;
        public InventarioManager(InventarioRepository inventarioRepository,
            IRepository<Producto> productoRepository)
        {
            _inventarioRepository = inventarioRepository;
            _productoRepository = productoRepository;
        }

       
        public StockVenta AgregarAtockVenta(int productoId, int cantidad)
        {
            // Obtener el inventario de la bodega.
            var inventarioBodega =  _inventarioRepository.Obtener(productoId,1);
            
            // Si no hay suficiente stock en la bodega, lanza una excepción o retorna un error.
            if (inventarioBodega.Cantidad < cantidad)
            {
                throw new Exception("No hay suficiente stock en la bodega.");
            }

            // Disminuye la cantidad en la bodega.
            inventarioBodega.ModificarCantidad(-cantidad);

            // Actualiza el inventario en la bodega.
            _inventarioRepository.Editar(inventarioBodega);

            // Obtener el inventario de venta.
            var inventarioVenta = _inventarioRepository.Obtener(productoId,2);

            // Aumenta la cantidad en el inventario de venta.
            inventarioVenta.ModificarCantidad(cantidad);

            // Actualiza el inventario de venta.
            _inventarioRepository.Editar(inventarioVenta);
            var p = _productoRepository.Obtener(productoId);
            return new StockVenta { Cantidad = inventarioVenta.Cantidad, Id =inventarioVenta.Id, Producto = p};
        }

        public StockInventario AgregarStockBodega(int productoId, int cantidad)
        {
            // Obtener el inventario de la bodega.
            var inventarioBodega =  _inventarioRepository.Obtener(productoId, 1);
            if(inventarioBodega == null){
                inventarioBodega = new Inventario (productoId,cantidad, TipoInventario.Bodega);
            }
            // Disminuye la cantidad en la bodega.
            Console.WriteLine("{0}",inventarioBodega);
            inventarioBodega.ModificarCantidad(+cantidad);
            Console.WriteLine("cantidad {0}",inventarioBodega.Cantidad);
            Console.WriteLine("productoId {0}",inventarioBodega.ProductoId);
            Console.WriteLine("productoId {0}",inventarioBodega.Tipo);
            // Actualiza el inventario en la bodega.
            _inventarioRepository.Agregar(inventarioBodega);

            return new StockInventario { Cantidad = inventarioBodega.Cantidad, Id =inventarioBodega.Id};
        }

        public StockInventario ObtenerStockBodega(int id){
            var inventarioBodega =  _inventarioRepository.Obtener(id,1);
            Console.WriteLine("{0}",inventarioBodega);
            return new StockInventario { Cantidad = inventarioBodega.Cantidad, Id =inventarioBodega.Id};
        }
        // Otros métodos para la gestión del inventario (agregar producto, eliminar producto, etc.)
    }

}