using Benito.Model.Entities.ECommerce;

public interface IProductoRepository {
    void Editar(Producto producto);
    Producto Crear(Producto producto);
    Producto Obtener(int productoId);
    List<Producto> Listar();
    


}