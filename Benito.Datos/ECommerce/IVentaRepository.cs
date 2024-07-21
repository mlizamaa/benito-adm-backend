using Benito.Model.Entities.ECommerce;

public interface IVentaRepository {
    void Editar(Venta inventario);
    Venta Crear(Venta inventario);
    Venta Obtener(int productoId);
    List<Venta> Listar();
    


}