
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Model.Entities.ECommerce;

namespace Benito.Negocio.Managers.ECommerce{

    public interface IProductoManager
    {
       
        ProductoDto Crear(ProductoDto producto);

        List<ProductoDto> Listar();
        ProductoDto Obtener(int id);
        ProductoDto Obtener(Guid id);
        ProductoDto Actualizar(ProductoDto producto);
        void Eliminar(int id);
        void Eliminar(Guid id);
    }

}