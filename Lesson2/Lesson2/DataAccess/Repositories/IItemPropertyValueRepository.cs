using DataAccess.DTO;

namespace DataAccess.Repositories
{
    public interface IItemPropertyValueRepository
    {
        Task UpsertAsync(ItemPropertyValue itemPropertyValue);
    }
}
