using Domain;
using Domain.Items;

namespace Services
{
    public interface IItemsService
    {
        Task<IEnumerable<IItemModel>> GetAllItems();

        Task WearInsert(Wear wear);
    }
}
