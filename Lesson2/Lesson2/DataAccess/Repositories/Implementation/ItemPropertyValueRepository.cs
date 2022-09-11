using DataAccess.DBContext;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation
{
    internal class ItemPropertyValueRepository : IItemPropertyValueRepository
    {
        private readonly SportsStoreItemsContext _dbContext;

        public ItemPropertyValueRepository()
        {
            _dbContext = new SportsStoreItemsContext();
        }

        public async Task UpsertAsync(ItemPropertyValue itemPropertyValue)
        {
            var property = await _dbContext.ItemPropertyValues.Where(x => x.PropertyId == itemPropertyValue.PropertyId 
                                                                 && x.ItemId == itemPropertyValue.ItemId)
                                                              .FirstOrDefaultAsync();

            if (property is null)
            {
                if (itemPropertyValue.Id == Guid.Empty) itemPropertyValue.Id = Guid.NewGuid();
                await _dbContext.AddAsync(itemPropertyValue);
            }
            else
                _dbContext.Update(itemPropertyValue);
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
