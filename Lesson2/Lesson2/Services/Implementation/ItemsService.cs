using DataAccess.DTO;
using DataAccess.Repositories;
using Domain;
using Domain.Items;

namespace Services.Implementation
{
    internal class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IItemPropertyValueRepository _itemPropertyValueRepository;

        public ItemsService(IItemsRepository itemsRepository, IItemPropertyValueRepository itemPropertyValueRepository)
        {
            _itemsRepository = itemsRepository;
            _itemPropertyValueRepository = itemPropertyValueRepository;
        }

        public async Task<IEnumerable<IItemModel>> GetAllItems()
        {
            var items = await _itemsRepository.GetAllItemsAsync();
            return items.Select(ItemModel.FromDbItem);
        }

        public async Task WearInsert(Wear wear)
        {
            var item = new Item
            {
                Id = wear.Id,
                ItemType = wear.ItemType,
                Name = wear.Name,
                Description = wear.Description
            };

            await _itemsRepository.InsertAsync(item);
        }
    }
}
