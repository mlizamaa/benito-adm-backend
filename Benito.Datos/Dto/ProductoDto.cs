namespace Benito.Datos.Dto
{
    public class ProductoDto
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
}