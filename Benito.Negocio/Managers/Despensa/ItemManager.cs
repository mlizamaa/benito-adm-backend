using Benito.Datos;
using Benito.Model.Entities.Despensa;

namespace Benito.Negocio.Managers.Despensa
{
    public class ItemManager : IItemManager
    {
        private readonly IBenitoBaseRepository<ItemDespensa> _itemRepository;
        public ItemManager(IBenitoBaseRepository<ItemDespensa> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<ItemDespensa> Agregar(ItemDespensa item, int cantidad)
        {
            var i  = await _itemRepository.Get(item.Id);
            i.EnStock= true;
            i.Cantidad += cantidad;
            i.FecModifica = DateTime.Now;
            await _itemRepository.Update(i);
            return i;
        }

        public async Task<ItemDespensa> Descontar(ItemDespensa item, int cantidad)
        {
             var i  = await _itemRepository.Get(item.Id);
            i.EnStock= item.EnStock;
            //i.Cantidad -= cantidad;
            //i.Cantidad = i.Cantidad < 0 ? 0 : i.Cantidad;
            //i.EnStock = (i.Cantidad > 0);

            i.FecModifica = DateTime.Now;
            await _itemRepository.Update(i);
            return i;
        }
    }
}