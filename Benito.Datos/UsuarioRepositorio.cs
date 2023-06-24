using Benito.Datos;
using Benito.Datos.Modelo;
using Microsoft.Extensions.Configuration;

namespace Benito.Datos.Repositorio {
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override string NombreTabla => "Usuarios";

        protected override string NombreProcedimientoAgregar => "Usuario_Agregar";
        protected override string NombreProcedimientoListar => "Usuario_Listar";
        protected override string NombreProcedimientoObtener => "Usuario_Obtener";
        protected override string NombreProcedimientoEliminar => "Usuario_Eliminar";
        protected override string NombreProcedimientoEditar => "Usuario_Editar";
    }

}