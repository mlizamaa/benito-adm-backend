

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
    public int Id { get; set; }
  public string CodigoBarra { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Precio { get; set; }
        public decimal? PrecioOferta { get; set; }
        public bool Oferta { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Marca { get; set; }
        public string Tamano { get; set; }
        public string Imagen { get; set; }
        public string CodTipo { get; set; }
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


}