using Benito.Model.Entities.Despensa;
namespace Benito.Negocio.Managers.Despensa
{
    public interface IItemManager {
        Task<ItemDespensa> Agregar(ItemDespensa item,int cantidad);
         Task<ItemDespensa> Descontar(ItemDespensa item,int cantidad);

    }
}