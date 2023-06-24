
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.Modelo;

namespace Benito.Negocio {

    public interface IProductoManager
    {
       
        ProductoDTO RegistrarProducto(string nombre, decimal precio);

        List<ProductoDTO> ObtenerProductos();
    }

}