namespace Benito.Model.Entities.ECommerce{
    public class Venta : BenitoBaseEntity
    {
        public List<ItemVenta>? Productos { get; set; }
        public DateTime FechaVenta { get; set; }
        public float MontoNeto { get; set; }
        public float MontoBruto { get; set; }
        public float Iva { get; set; }
    }
}
