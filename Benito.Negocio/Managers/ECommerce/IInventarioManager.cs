
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Model.Entities.ECommerce;

namespace Benito.Negocio.Managers.ECommerce {

  public interface IInventarioManager
    {
        StockVenta AgregarAtockVenta(int productoId, int cantidad);
        InventarioBodega AgregarInventarioBodega(int productoId, int cantidad);
        InventarioBodega ObtenerInventarioBodega(int id);
        List<InventarioBodega> ListarInventarioBodega();
    }  
}