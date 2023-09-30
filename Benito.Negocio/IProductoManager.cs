
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.ECommerce.Modelo;

namespace Benito.Negocio {

    public interface IProductoManager
    {
       
        ProductoDTO Crear(ProductoDTO producto);

        List<ProductoDTO> Listar();
        ProductoDTO Obtener(int id);
        ProductoDTO Actualizar(ProductoDTO producto);
        void Eliminar(int id);
    }

}