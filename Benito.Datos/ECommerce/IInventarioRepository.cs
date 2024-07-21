using Benito.Model.Entities.ECommerce;

interface IInventarioRepository {
    void Editar(Inventario inventario);
    Inventario Crear(IInventarioRepository inventario);
    Inventario Obtener(int productoId);
    List<Inventario> Listar();
    


}