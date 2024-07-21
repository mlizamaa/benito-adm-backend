using Benito.Model.Entities.ECommerce;
using Benito.Datos.Repositorio;
using Microsoft.Extensions.Configuration;

public class ProductoRepository : BaseRepository<Producto>
{
    public ProductoRepository(IConfiguration configuration) : base(configuration)
    {
    }

    protected override string NombreTabla => throw new NotImplementedException();

    protected override string NombreProcedimientoAgregar => "PRODUCTO_CREAR";

    protected override string NombreProcedimientoListar => "PRODUCTO_LISTAR";

    protected override string NombreProcedimientoObtener => "PRODUCTO_OBTENER";

    protected override string NombreProcedimientoEliminar => "PRODUCTO_ELIMINAR";

    protected override string NombreProcedimientoEditar => "PRODUCTO_ACTUALIZAR";
}