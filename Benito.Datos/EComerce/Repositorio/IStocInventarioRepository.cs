using Benito.Datos.ECommerce.Modelo;

namespace Benito.Datos.Repositorio
{
  public interface IInventarioRepository{
    Inventario Agregar(Inventario entidad);
    List<Inventario> Listar(int tipo);
    Inventario Obtener(int ProductoId, int tipo);
    void Eliminar(int id);
    Inventario Editar(Inventario entidad);
}
}