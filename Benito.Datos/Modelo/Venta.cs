namespace Benito.Datos.Modelo{
    public class Venta
    {
        public int Id { get; set; }
        public List<Producto> Productos { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
