
using Benito.Datos.Repositorio;
using Benito.Model.Entities.ECommerce;

using AutoMapper;
using Benito.Datos.ECommerce;
namespace Benito.Negocio.Managers.ECommerce {

    

    public class InventarioManager : IInventarioManager
    {
        private readonly IStockInventarioRepository _inventarioRepository;
        private readonly IRepositorioCrud<Producto> _productoRepository;
        public InventarioManager(IStockInventarioRepository inventarioRepository,
            IRepositorioCrud<Producto> productoRepository)
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
                inventarioBodega = new InventarioBodega{ 
                    ProductoId =  productoId,
                    Cantidad = cantidad
                    };
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