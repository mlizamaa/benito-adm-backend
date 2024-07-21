namespace Benito.Model.Entities.ECommerce {
    public class Usuario : BenitoBaseEntity
    {
        public string? Nombre { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }
    }

}