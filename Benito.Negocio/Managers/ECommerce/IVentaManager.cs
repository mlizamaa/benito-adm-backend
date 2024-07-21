
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Model.Entities.ECommerce;

namespace Benito.Negocio.Managers.ECommerce {
    public interface IVentaManager
    {
       
        Venta Registrar(Venta items);
    }

}