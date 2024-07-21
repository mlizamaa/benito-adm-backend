using Benito.Model;

namespace Benito.Model.Entities.Huerto
{
    public class Plantacion : BenitoBaseEntity
    {
        public Guid HuertoId { get; set; }
        public int Largo { get; set; }
        public int Ancho { get; set; }
        public Guid EspecieId { get; set; }
        public DateTime FechaPlantacion { get; set; }
        public DateTime? FechaCosecha { get; set; }
        public int Cantidad { get; set; }
        public int CantidadCosechada { get; set; }
        public int CantidadPendiente { get; set; }
        public string? Observaciones { get; set; }

    }

}