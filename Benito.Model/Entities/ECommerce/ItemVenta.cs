namespace Benito.Model.Entities.ECommerce{
    public class ItemVenta : BenitoBaseEntity
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string? Detalle { get; set; }
        public int Cantidad {get; set;}
        public float MontoNeto { get; set; }
        public float MontoBruto { get; set; }
        public float Iva { get; set; }
    }
}
