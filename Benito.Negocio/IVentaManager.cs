
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.ECommerce.Modelo;

namespace Benito.Negocio {

    public interface IVentaManager
    {
       
        Venta Registrar(List<ItemVenta> items);
    }

}