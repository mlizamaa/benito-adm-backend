namespace Benito.Datos.Modelo{
   public class Inventario
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    //public Producto Producto { get; set; }  // Relación con Producto
    public int Cantidad { get; set; }
    public int Tipo { get; set; }  // Diferencia entre inventario de bodega y de venta

    public Inventario(int id, int productoId, int cantidad,  int tipo)
    {
        ProductoId = productoId;
        Cantidad = cantidad;
        Tipo = tipo;
        Id = id;
    }

    public Inventario(int productoId, int cantidad, int tipo)
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
