using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Datos.Despensa;
using Benito.Model.Dto.Despensa;
using Benito.Model.Entities.Despensa;
using Benito.Negocio;
using Benito.Negocio.Managers.Despensa;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;


using Microsoft.AspNetCore.Mvc;
namespace Benito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespensaController : BenitoControllerBase<ItemDespensa>
    {
        //crea constructor con inyección de dependencia ProductoManager
        // Ejemplo de repositorio especifico
        private readonly IItemRepository _itemRepository;
        // Ejemplo de repositorio generico
        private readonly IBenitoBaseRepository<ItemDespensa> _benitoBaseRepository;
        private readonly IItemManager _itemManager;

        public DespensaController(IItemRepository itemRepository, 
            IBenitoBaseRepository<ItemDespensa> benitoBaseRepository,
            IItemManager itemManager            
            ) : base(benitoBaseRepository) {
            _itemRepository = itemRepository;
            _benitoBaseRepository = benitoBaseRepository;
            _itemManager = itemManager;
            
        }

        [HttpPost("item/agregar")]
        public async Task<IActionResult> AgregarProducto(ItemDespensaDto item, int cantidad)
        {
            var i = new ItemDespensa{
                Id = item!.Id!.Value,
            };
            
            i = await _itemManager.Agregar(i, cantidad);
            return Ok(i);
        }
        
        [HttpPost("item/descontar")]
        public async Task<IActionResult> DescontarProducto(ItemDespensaDto item, int cantidad)
        {
            var i = new ItemDespensa{
                Id = item!.Id!.Value,
                Nombre = item.Nombre,
                Cantidad = item.Cantidad!.Value,
                EnStock = item.EnStock!.Value,
            };
            
            i = await _itemManager.Descontar(i, cantidad);
            return Ok(i);
        }
   
        [HttpPost("item/crear")]
        public async Task<IActionResult> CrearProducto(ItemDespensaDto item)
        {
            var i = new ItemDespensa{
                Nombre = item.Nombre,
                Cantidad = item.Cantidad!.Value,
                EnStock = (item.Cantidad.GetValueOrDefault(0) ! > 0),
            };
            
            i = await _benitoBaseRepository.AddAsync(i);
            return Ok(i);
        }

        ///
        [HttpPost("item/listar")]
        public async Task<IActionResult> ListarProductos(ICollection<KeyValuePair<string,string>> filtros)
        {
            try
            {
                var items = await _benitoBaseRepository.GetAllAsync();
                var lista = items.ToList();
                // aplicar filtros

                if (filtros != null)
                {
                    foreach (var filtro in filtros)
                    {
                        switch (filtro.Key.ToLower())
                        {
                            case "nombre":
                                lista = lista.Where(i => filtro.Value.ToLower().Split(",").Contains(i.Nombre!.ToLower())).ToList();
                                break;
                            case "tipo":
                                lista = lista.Where(i => i.Tipo!.Contains(filtro.Value.ToLower())).ToList();
                                break;
                            case "enstock":
                                lista = lista.Where(i => i.EnStock!.ToString().Contains(filtro.Value.ToLower())).ToList();
                                break;
                            case "cantidad":
                                lista = lista.Where(i => i.Cantidad!.ToString().Contains(filtro.Value.ToLower())).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new KeyNotFoundException("No existe el objeto");
            }
            
        }
    }
}
      