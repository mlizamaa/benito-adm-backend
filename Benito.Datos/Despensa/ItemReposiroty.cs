using Benito.Model.Entities.Despensa;
using Microsoft.EntityFrameworkCore;

namespace Benito.Datos.Despensa
{
    public class ItemRepository : IItemRepository
    {
        private readonly BenitoDbContext _context;

        public ItemRepository(BenitoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemDespensa>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<ItemDespensa> GetItem(Guid id)
        {
            return await _context.Items.FindAsync(id)! ?? throw new KeyNotFoundException("No existe el objeto");
        }

        public ItemDespensa CreateItem(ItemDespensa item)
        {
            item.Id = Guid.NewGuid();
            _context.Items.Add (item);
            _context.SaveChanges();
            return item;
        }

        public async Task UpdateItem(ItemDespensa item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Guid id)
        {
            var itemToDelete = await _context.Items.FindAsync(id);
            _context.Items.Remove(itemToDelete!);
            await _context.SaveChangesAsync();
        }
    }

    public interface IItemRepository
    {
        Task<IEnumerable<ItemDespensa>> GetItems();
        Task<ItemDespensa> GetItem(Guid id);
        ItemDespensa CreateItem(ItemDespensa item);
        Task UpdateItem(ItemDespensa item);
        Task DeleteItem(Guid id);
    }
}