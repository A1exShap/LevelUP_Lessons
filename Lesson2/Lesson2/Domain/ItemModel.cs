using DataAccess.DTO;

namespace Domain
{
    public record ItemModel : IItemModel
    {
        public static IItemModel FromDbItem(Item item)
        {
            var itemTypeName = item.ItemTypes.Name;
            IItemModel productItem = itemTypeName switch
            {
                ItemTypeNames.Wear => ItemFactory.CreateWear(item),
                _ => throw new InvalidOperationException($"Couldn't process product type '{itemTypeName}'")
            };

            return productItem;
        }

        public Guid Id { get; init; }

        public Guid ItemType { get; init; }

        public string? Name { get; init; }

        public string? Description { get; init; }
    }
}
