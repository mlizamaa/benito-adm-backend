using Microsoft.AspNetCore.Mvc;
using Benito.Negocio.Managers.ECommerce;
using Benito.Datos.Dto;
namespace Benito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoManager _productoManager;
        //crea constructor con inyección de dependencia ProductoManager
        public ProductoController(IProductoManager productoManager)
        {
            _productoManager = productoManager;
        }

        // metodo para listar productos mediante el manager
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_productoManager.Obtener(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int id)
        {
            return Ok(_productoManager.Listar());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductoDto producto)
        {
            try{
                return Ok(_productoManager.Crear(producto));
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductoDto producto)
        {
            return Ok(_productoManager.Actualizar(producto));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productoManager.Eliminar(id);
            return Ok();
        }
    }
}