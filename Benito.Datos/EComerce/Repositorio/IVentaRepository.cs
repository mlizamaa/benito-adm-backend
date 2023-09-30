using Benito.Datos.ECommerce.Modelo;

namespace Benito.Datos.Repositorio
{
  public interface IVentaRepository{
    Venta Add(List<ItemVenta> items);
    List<Venta> List();
    Venta Get(string nroVenta);
}
}