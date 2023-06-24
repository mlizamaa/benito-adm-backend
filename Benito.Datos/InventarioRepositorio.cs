using System;
using System.Data;
using System.Data.SqlClient;
using Benito.Datos.Modelo;
using Benito.Datos.Repositorio;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Benito.Datos.Repositorio {
public interface IInventarioRepository{
    Inventario Agregar(Inventario entidad);
    List<Inventario> Listar(int tipo);
    Inventario Obtener(int id, int tipo);
    void Eliminar(int id);
    Inventario Editar(Inventario entidad);
}
   public class InventarioRepository : IInventarioRepository
    {
        private string _connectionString;
        public InventarioRepository(IConfiguration configuration)
        {
             // _connectionString = configuration.GetConnectionString("sql");
        _connectionString = "Server=localhost,1433; Database=benito; User ID=sa; Password=Marcelo1597;";
        }

        
        public List<Inventario> Listar(int tipo) {
            using (var connection = new SqlConnection(_connectionString))
            {

                var parametros = new DynamicParameters();
                parametros.Add("@Tipo", tipo);
                var resultado = connection.Query<List<Inventario>>(NombreProcedimientoAgregar, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return resultado;
            }
        }
        
        public Inventario Obtener(int id, int tipo) {
            using (var connection = new SqlConnection(_connectionString))
            {

                var parametros = new DynamicParameters();
                parametros.Add("@Id", id);
                parametros.Add("@Tipo", tipo);
                var resultado = connection.Query<Inventario>(NombreProcedimientoObtener, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return resultado;
            }
        }
        public Inventario Agregar(Inventario entidad){
            using (var connection = new SqlConnection(_connectionString))
            {

                var parametros = new DynamicParameters();
                parametros.Add("@ProductoId", entidad.ProductoId);
                parametros.Add("@Cantidad", entidad.Cantidad);
                parametros.Add("@Tipo", (int)entidad.Tipo);
                
                var resultado = connection.Execute(NombreProcedimientoAgregar, parametros, commandType: CommandType.StoredProcedure);
                Console.WriteLine("sp {0}", NombreProcedimientoAgregar);
                Console.WriteLine("cantidad {0}",entidad.Cantidad);
                Console.WriteLine("productoId {0}",entidad.ProductoId);
                Console.WriteLine("tipo {0}",((int)entidad.Tipo)+1);
                Console.WriteLine("RESULTADO {0}",resultado);
                return entidad;
            }
        }
        public void Eliminar(int id){
            throw new NotImplementedException();
        }
        public Inventario Editar(Inventario entidad){
            throw new NotImplementedException();
        }

        private string NombreTabla => "Inventario";
        private string NombreProcedimientoAgregar => "Inventario_Agregar";
        private string NombreProcedimientoListar => "Inventario_Listar";
        private string NombreProcedimientoObtener => "Inventario_Obtener";
        private string NombreProcedimientoEliminar => "Inventario_Eliminar";
        private string NombreProcedimientoEditar => "Inventario_Editar";
        private string NombreProcedimientoActualizar => "Inventario_Actualizar";
}


}