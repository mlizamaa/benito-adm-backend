﻿namespace Benito.Datos.ECommerce.Modelo{
    public class StockVenta
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }

}
