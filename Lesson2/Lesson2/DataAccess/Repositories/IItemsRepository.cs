using DataAccess.DTO;

namespace DataAccess.Repositories
{
    public interface IItemsRepository
    {
        Task<Item[]> GetAllItemsAsync();

        Task InsertAsync(Item item);
    }
}
