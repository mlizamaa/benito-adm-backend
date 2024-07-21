
using Benito.Model.Entities.ECommerce;
namespace Benito.Negocio.Managers.ECommerce {

    public class VentaManager : IVentaManager
    {
       private IVentaRepository _ventaRepository;
       public VentaManager(IVentaRepository ventaRepository){
        _ventaRepository = ventaRepository;
       }
        public Venta Registrar(Venta venta){
            return _ventaRepository.Crear(venta);
        }

        
    }

}