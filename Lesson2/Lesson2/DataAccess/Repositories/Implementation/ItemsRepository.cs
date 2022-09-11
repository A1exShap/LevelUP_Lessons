using DataAccess.DBContext;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation
{
    internal class ItemsRepository : IItemsRepository
    {
        private readonly SportsStoreItemsContext _dbContext;

        public ItemsRepository()
        {
            _dbContext = new SportsStoreItemsContext();
        }

        public async Task<Item[]> GetAllItemsAsync()
        {
            return await (_dbContext.Items
                                    .AsNoTracking()
                                    .Include(item => item.ItemTypes))
                                    .ToArrayAsync();
        }

        public async Task InsertAsync(Item item)
        {
            if (item is null)
                throw new ArgumentNullException();

            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            await _dbContext.Items.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
