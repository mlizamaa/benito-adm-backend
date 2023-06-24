using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
namespace Benito.Datos.Repositorio{

    public abstract class BaseRepository<T> : IRepository<T>
{
    protected string _connectionString;

    public BaseRepository(IConfiguration configuration)
    {
       // _connectionString = configuration.GetConnectionString("sql");
        _connectionString = "Server=localhost,1433; Database=benito; User ID=sa; Password=Marcelo1597;";
    }

    protected abstract string NombreTabla { get; }

    protected abstract string NombreProcedimientoAgregar { get; }
    protected abstract string NombreProcedimientoListar { get; }
    protected abstract string NombreProcedimientoObtener { get; }
    protected abstract string NombreProcedimientoEliminar { get; }
    protected abstract string NombreProcedimientoEditar { get; }

    public T Agregar(T entidad)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parametros = entidad.ToDynamicParameters();
            var resultado = connection.Query<T>(NombreProcedimientoAgregar, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return resultado;
        }
    }

    public List<T> Listar()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var resultado = connection.Query<T>(NombreProcedimientoListar, commandType: CommandType.StoredProcedure).ToList();
            return resultado;
        }
    }

    public T Obtener(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parametros = new DynamicParameters();
            parametros.Add("Id", id);
            var resultado = connection.Query<T>(NombreProcedimientoObtener, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return resultado;
        }
    }

    public void Eliminar(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parametros = new DynamicParameters();
            parametros.Add("Id", id);
            connection.Execute(NombreProcedimientoEliminar, parametros, commandType: CommandType.StoredProcedure);
        }
    }

    public T Editar(T entidad)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parametros = entidad.ToDynamicParameters();
            var resultado = connection.Query<T>(NombreProcedimientoEditar, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault();
            return resultado;
        }
    }
}


}