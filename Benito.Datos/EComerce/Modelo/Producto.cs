namespace Benito.Datos.ECommerce.Modelo {
    public class Producto
    {
        public int Id { get; set; }
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

}

