
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
        InventarioBodega AgregarInventarioBodega(int productoId, int cantidad);
        InventarioBodega ObtenerInventarioBodega(int id);
        List<InventarioBodega> ListarInventarioBodega();
    }

    public class InventarioManager : IInventarioManager
    {
        private readonly StockInventarioRepository _inventarioRepository;
        private readonly IRepository<Producto> _productoRepository;
        public InventarioManager(StockInventarioRepository inventarioRepository,
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
            //var inventarioBodega = _inventarioRepository.Obtener(productoId,1);

            // Aumenta la cantidad en el inventario de venta.
            //inventarioVenta.ModificarCantidad(cantidad);

            // Actualiza el inventario de venta.
            //_inventarioRepository.Editar(inventarioVenta);
            var p = _productoRepository.Obtener(productoId);
            return new StockVenta { Cantidad = inventarioBodega.Cantidad, Id = inventarioBodega.Id, Producto = p};
        }

        public InventarioBodega AgregarInventarioBodega(int productoId, int cantidad)
        {
            // Obtener el inventario de la bodega.
            var inventarioBodega =  _inventarioRepository.Obtener(productoId, 1);
            if(inventarioBodega == null){
                inventarioBodega = new Inventario (productoId,cantidad, 1);
                _inventarioRepository.Agregar(inventarioBodega);
            }
            else {
                inventarioBodega.ModificarCantidad(+cantidad);
                _inventarioRepository.Editar(inventarioBodega);
            }
            // Disminuye la cantidad en la bodega.

            return new InventarioBodega { Cantidad = inventarioBodega.Cantidad, Id =inventarioBodega.Id};
        }

        public InventarioBodega ObtenerInventarioBodega(int id){
            var inventarioBodega =  _inventarioRepository.Obtener(id,1);
            Console.WriteLine("{0}",inventarioBodega);
            return new InventarioBodega { Cantidad = inventarioBodega.Cantidad, Id =inventarioBodega.Id};
        }
        // Otros métodos para la gestión del inventario (agregar producto, eliminar producto, etc.)

        public List<InventarioBodega> ListarInventarioBodega(){
            return _inventarioRepository.Listar(1).Select(i=> new InventarioBodega{
                Cantidad = i.Cantidad,
                Id = i.Id,
                ProductoId = i.ProductoId
            }).ToList();
        }
    }

}