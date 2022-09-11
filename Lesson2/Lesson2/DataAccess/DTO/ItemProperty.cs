using System;
using System.Collections.Generic;

namespace DataAccess.DTO
{
    public partial class ItemProperty
    {
        public ItemProperty()
        {
            ItemPropertyValues = new HashSet<ItemPropertyValue>();
        }

        public Guid Id { get; set; }
        public Guid ItemTypeId { get; set; }
        public string Name { get; set; } = null!;
        public short ValueType { get; set; }
        public bool IsActive { get; set; }

        public virtual ItemType ItemType { get; set; } = null!;
        public virtual ICollection<ItemPropertyValue> ItemPropertyValues { get; set; }
    }
}
