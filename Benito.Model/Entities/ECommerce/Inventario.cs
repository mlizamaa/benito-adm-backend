namespace Benito.Model.Entities.ECommerce{
   public class Inventario : BenitoBaseEntity
{
    // Id del inventario, auto incremental
    
    
    // Relación con la tabla Producto
    public int ProductoId { get; set; }
    // Relación con la tabla Producto
    public Producto? Producto { get; set; }
    public int Cantidad { get; set; }
    
    // Tipo de inventario, si es de bodega o de venta, se asigna con el enum TipoInventario
    public int Tipo { get; set; }  

    /// <summary>
    /// Constructor vacío para Entity Framework
    /// </summary>
    /// <param name="id">Id del producto, se inicializa por defecto en cero y se asigna automaticamente por la base de datos</param>
    /// <param name="productoId">Id del producto a inventariar</param>
    /// <param name="cantidad"> Cantidad del producto en inventario</param>
    /// <param name="tipo">Tipo de inventario, Bodega o Venta</param>
    public Inventario(int id, int productoId, int cantidad,  int tipo)
    {
        ProductoId = productoId;
        Cantidad = cantidad;
        Tipo = tipo;
        Id = Guid.NewGuid();
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
