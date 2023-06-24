namespace Benito.Datos.Modelo{
   public class Inventario
{
    public int Id { get; private set; }
    public int ProductoId { get; private set; }
    public Producto Producto { get; private set; }  // Relación con Producto
    public int Cantidad { get; private set; }
    public TipoInventario Tipo { get; private set; }  // Diferencia entre inventario de bodega y de venta

    public Inventario(int Id, int productoId, int cantidad,  TipoInventario tipo)
    {
        ProductoId = productoId;
        Cantidad = cantidad;
        Tipo = tipo;
    }

    public Inventario(int productoId, int cantidad, TipoInventario tipo)
    {
        ProductoId = productoId;
        Cantidad = cantidad;
        Tipo = tipo;
    }

    // Método para agregar o quitar productos del inventario
    public void ModificarCantidad(int cantidad)
    {
        if (Cantidad + cantidad < 0)
        {
            throw new Exception("La cantidad de productos en el inventario no puede ser negativa.");
        }

        Cantidad += cantidad;
    }
}

// Enum para diferenciar entre inventario de bodega y de venta
public enum TipoInventario
{
    Bodega,
    Venta
}
}
