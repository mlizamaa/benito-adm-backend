using Benito.Model.Entities.ECommerce;

namespace Benito.Datos.ECommerce
{
    public interface IStockInventarioRepository
    {
        InventarioBodega Agregar(InventarioBodega entidad);
        InventarioBodega Editar(InventarioBodega entidad);
        void Eliminar(int id);
        InventarioBodega Obtener(int productoId, int bodegaId);
        List<InventarioBodega> Listar(int productoId);
    }
}