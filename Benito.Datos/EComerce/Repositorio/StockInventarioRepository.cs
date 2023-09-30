using System;
using System.Data;
using System.Data.SqlClient;
using Benito.Datos.ECommerce.Modelo;
using Benito.Datos.Repositorio;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Benito.Datos.Repositorio {

   public class StockInventarioRepository : IInventarioRepository
    {
        private string _connectionString;
        public StockInventarioRepository(IConfiguration configuration)
        {
             // _connectionString = configuration.GetConnectionString("sql");
        _connectionString = "Server=localhost,1433; Database=benito; User ID=sa; Password=Marcelo1597;";
        }

        
        public List<Inventario> Listar(int tipo) {
            using (var connection = new SqlConnection(_connectionString))
            {

                //var parametros = new DynamicParameters();
                //parametros.Add("@Tipo", tipo);
                var resultado = connection.Query<Inventario>(NombreProcedimientoListar, commandType: CommandType.StoredProcedure).ToList();
                return resultado;
            }
        }
        
        public Inventario Obtener(int ProductoId, int tipo) {
            using (var connection = new SqlConnection(_connectionString))
            {

                var parametros = new DynamicParameters();
                parametros.Add("@ProductoId", ProductoId);
                parametros.Add("@Tipo", tipo);
                var resultado = connection.Query<Inventario>(NombreProcedimientoObtener, parametros, commandType: CommandType.StoredProcedure).SingleOrDefault()!;
                return resultado;
            }
        }
        public Inventario Agregar(Inventario entidad){
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@ProductoId", entidad.ProductoId);
                parametros.Add("@cantidad", entidad.Cantidad);
                parametros.Add("@Tipo", entidad.Tipo
                );
                var resultado = connection.Execute(NombreProcedimientoAgregar, parametros, commandType: CommandType.StoredProcedure);
                return entidad;
            }
        }
        public void Eliminar(int id){
            throw new NotImplementedException();
        }
        public Inventario Editar(Inventario entidad){
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", entidad.Id);
                parametros.Add("@Cantidad", entidad.Cantidad);
                var resultado = connection.Execute(NombreProcedimientoActualizar, parametros, commandType: CommandType.StoredProcedure);
                return entidad;
            }    
        }

        private string NombreTabla => "Inventario";
        private string NombreProcedimientoAgregar => "StockInventario_Agregar";
        private string NombreProcedimientoListar => "StockInventario_Listar";
        private string NombreProcedimientoObtener => "StockInventario_Obtener";
        private string NombreProcedimientoEliminar => "StockInventario_Eliminar";
        private string NombreProcedimientoEditar => "StockInventario_Editar";
        private string NombreProcedimientoActualizar => "StockInventario_Actualizar";
}


}