namespace Benito.Datos.ECommerce.Modelo{
    public class Venta
    {
        public int Id { get; set; }
        //public List<ItemVenta> Productos { get; set; }
        public DateTime FechaVenta { get; set; }
        public float MontoNeto { get; set; }
        public float MontoBruto { get; set; }
        public float Iva { get; set; }
    }
}
