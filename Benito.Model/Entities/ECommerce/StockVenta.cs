namespace Benito.Model.Entities.ECommerce{
    public class StockVenta : BenitoBaseEntity
    {
        public Producto? Producto { get; set; }
        public int Cantidad { get; set; }
    }

}
