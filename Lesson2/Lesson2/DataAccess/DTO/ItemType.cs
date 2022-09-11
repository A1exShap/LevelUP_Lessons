using System;
using System.Collections.Generic;

namespace DataAccess.DTO
{
    public partial class ItemType
    {
        public ItemType()
        {
            ItemProperties = new HashSet<ItemProperty>();
            Items = new HashSet<Item>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ItemProperty> ItemProperties { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
