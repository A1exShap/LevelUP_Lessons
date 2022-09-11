using DataAccess.DTO;
using Domain.Items;
using Domain.Enums;

namespace Domain
{
    public static class ItemFactory
    {
        public static Wear CreateWear(Item item)
        {
            return new Wear
            {
                Id = item.Id, 
                ItemType = item.ItemType,
                Name = item.Name,
                Description = item.Description,
                Size = GetString(ItemPropertyNames.Size, item)
            };
        }

        private static string? GetString(string propertyName, Item item)
        {
            var propValue = GetPropertyValue(propertyName, item);

            var property = propValue?.Property;

            if (property?.ValueType == (int)PropertyValueType.String)
            {
                return propValue?.StringValue;
            }

            if (property?.ValueType == (int)PropertyValueType.EnumValue)
            {
                return propValue?.EnumValue?.StringValue;
            }

            return default;
        }

        private static ItemPropertyValue? GetPropertyValue(string propertyName, Item item)
            => item.ItemPropertyValues
                    .SingleOrDefault(value => value.Property.Name == propertyName);
    }
}
