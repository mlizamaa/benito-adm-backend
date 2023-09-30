namespace Benito.Datos.ECommerce.Modelo{
    public class ItemVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string Detalle { get; set; }
        public int Cantidad {get; set;}
        public float MontoNeto { get; set; }
        public float MontoBruto { get; set; }
        public float Iva { get; set; }
    }
}
