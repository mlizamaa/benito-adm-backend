using Benito.Datos.ECommerce.Modelo;
using Microsoft.Extensions.Configuration;

namespace Benito.Datos.Repositorio {
   public class ProductoRepository : BaseRepository<Producto> , IRepositorioCrud<Producto>
    {
        public ProductoRepository(IConfiguration configuration) : base(configuration)
        {
           
        }

        protected override string NombreTabla => "Productos";

        protected override string NombreProcedimientoAgregar => "Producto_Crear";
        protected override string NombreProcedimientoListar => "Producto_Listar";
        protected override string NombreProcedimientoObtener => "Producto_Obtener";
        protected override string NombreProcedimientoEliminar => "Producto_Eliminar";
        protected override string NombreProcedimientoEditar => "Producto_Actualizar";
}


}