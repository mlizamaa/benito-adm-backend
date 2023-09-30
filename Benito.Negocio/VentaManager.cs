
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.ECommerce.Modelo;
using Benito.Datos.Repositorio;

namespace Benito.Negocio {

    public class VentaManager : IVentaManager
    {
       private IVentaRepository _ventaRepository;
       public VentaManager(IVentaRepository ventaRepository){
        _ventaRepository = ventaRepository;
       }
        public Venta Registrar(List<ItemVenta> items){
            return _ventaRepository.Add(items);
        }
    }

}