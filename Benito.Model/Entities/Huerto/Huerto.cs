namespace Benito.Model.Entities.Huerto
{

    public class Huerto : BenitoBaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        List<Plantacion> Plantaciones { get; set; }

        public Huerto()
        {
            this.Id = Guid.NewGuid();
            this.Plantaciones = new List<Plantacion>();
        }

    }
}