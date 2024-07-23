using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Benito.Datos.Repositorio{

    public abstract class BaseRepository<T> : IRepositorioCrud<T>
{
    protected string _connectionString;

    public BaseRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("sql")!;
    }

    protected abstract string NombreTabla { get; }

    protected abstract string NombreProcedimientoAgregar { get; }
    protected abstract string NombreProcedimientoListar { get; }
    protected abstract string NombreProcedimientoObtener { get; }
    protected abstract string NombreProcedimientoEliminar { get; }
    protected abstract string NombreProcedimientoEditar { get; }

    public T Crear(T entidad)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            
            //serializar parametros a un json y pasar como parámetro al predimiento con el nombre de parametro @json
            var json = JsonConvert.SerializeObject(entidad);
            var parametros = new DynamicParameters();
            parametros.Add("jsonProducto", json);
            var resultado = connection.Query<T>(NombreProcedimientoAgregar, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault()!;
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
            var resultado = connection.Query<T>(NombreProcedimientoObtener, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault()!;
            return resultado;
        }
    }

    public void Eliminar(Guid id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var parametros = new DynamicParameters();
            parametros.Add("Id", id);
            connection.Execute(NombreProcedimientoEliminar, parametros, commandType: CommandType.StoredProcedure);
        }
    }

    public T Actualizar(T entidad)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
             //serializar parametros a un json y pasar como parámetro al predimiento con el nombre de parametro @json
            var json = JsonConvert.SerializeObject(entidad);
            var parametros = new DynamicParameters();
            parametros.Add("jsonProducto", json);
            var resultado = connection.Query<T>(NombreProcedimientoEditar, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault()!;
            return resultado;
        }
    }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public T Obtener(Guid id)
        {
             using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("Id", id);
                var resultado = connection.Query<T>(NombreProcedimientoObtener, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault()!;
                return resultado;
            }
        }
    }


}