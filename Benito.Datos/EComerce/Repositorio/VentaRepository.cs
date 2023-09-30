using System.Data;
using System.Data.SqlClient;
using Benito.Datos.ECommerce.Modelo;
using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Benito.Datos.Repositorio
{
  public class VentaRepository : IVentaRepository{
     private string _connectionString;
    public VentaRepository(IConfiguration configuration)
    {
      _connectionString = "Server=localhost,1433; Database=benito; User ID=sa; Password=Marcelo1597;";
    }

    public Venta Add(List<ItemVenta> items){
      using (var connection = new SqlConnection(_connectionString))
            {
                string jsonDetalle = JsonConvert.SerializeObject(items);
                var venta = new Venta {
                  Iva = items.Sum(i=> i.Iva),
                  MontoBruto = items.Sum(i=> i.MontoBruto),
                  MontoNeto = items.Sum(i=> i.MontoNeto),
                };

                string jsonVenta = JsonConvert.SerializeObject(venta);
                var parametros = new DynamicParameters();
                parametros.Add("@jsonVenta", jsonVenta);
                parametros.Add("@jsonDetalle", jsonDetalle);
                var resultado = connection.Query<Venta>("Venta_Insertar", parametros, commandType: CommandType.StoredProcedure).First();
                return resultado;
            }
    }

    public List<Venta> Listar(){
      // list all the products
      var ventas = new List<Venta>();
      using (var connection = new SqlConnection(_connectionString))
            {
                ventas = connection.Query<Venta>("Venta_Listar", commandType: CommandType.StoredProcedure).ToList();
            }
        
      return ventas;
    }

    public Venta Get(string nroVenta){
      var venta = new Venta();
      using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@nroVenta", nroVenta);
                venta = connection.Query<Venta>("Venta_Get", parametros, commandType: CommandType.StoredProcedure).First();
            }
        
      return venta; 
    }

        public List<Venta> List()
        {
            throw new NotImplementedException();
        }
    }
}