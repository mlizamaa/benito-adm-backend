

namespace Benito.Datos.Dto {
// DTO de Usuario
public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Usuario { get; set; }
}

// DTO de Producto
public class ProductoDTO
{
    public Guid Id { get; set; }
    public string Nombre{ get; set; }
    public string Resena { get; set; }
    public string Descripcion { get; set; }
    public string CodTipo { get; set; } 
    public bool McaBorrador  { get; set; }
    public string CodigoBarra  { get; set; }
    public decimal Precio  { get; set; }
    public decimal Descuento  { get; set; }
    public string Imagen  { get; set; }

    //información general del producto [{"codigo":"string", "valor":"string"}]
    public string Caracteristicas{ get; set; }  
    public bool McaEliminado { get; set; }
}

// DTO de Stock de Inventario
public class StockInventarioDTO
{
    public int Id { get; set; }
    public ProductoDTO Producto { get; set; }
    public int Cantidad { get; set; }
}

// DTO de Stock de Venta
public class StockVentaDTO
{
    public int Id { get; set; }
    public ProductoDTO Producto { get; set; }
    public int Cantidad { get; set; }
}

// DTO de Venta
public class VentaDTO
{
    public int Id { get; set; }
    public List<ProductoDTO> Productos { get; set; }
    public DateTime FechaVenta { get; set; }
}

public class AutenticacionDto{
    public string? Usuario { get; set; }
    public string? Password { get; set; }
}
}