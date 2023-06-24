using Microsoft.AspNetCore.Mvc;
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.Modelo;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Benito.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
   
    private readonly ILogger<ProductoController> _logger;
    private readonly IRepositorio<Producto> _productoManager;
    public ProductoController(ILogger<ProductoController> logger, IRepositorio<Producto> productoManager)
    {
        _logger = logger;
        _productoManager = productoManager;
    }

    [HttpPost]
    public IActionResult Post(string nombre, decimal precio)
    {
       return Ok(_productoManager.Agregar(new Producto { Nombre = nombre, Precio = precio }));
    }

    [HttpGet]
    public IActionResult Get()
    {
       return Ok(_productoManager.Listar());
    }
}
