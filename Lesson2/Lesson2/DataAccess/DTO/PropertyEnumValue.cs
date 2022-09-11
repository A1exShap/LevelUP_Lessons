using System;
using System.Collections.Generic;

namespace DataAccess.DTO
{
    public partial class PropertyEnumValue
    {
        public PropertyEnumValue()
        {
            ItemPropertyValues = new HashSet<ItemPropertyValue>();
        }

        public Guid Id { get; set; }
        public Guid EnumId { get; set; }
        public string? StringValue { get; set; }
        public decimal? NumericValue { get; set; }

        public virtual PropertyEnum Enum { get; set; } = null!;
        public virtual ICollection<ItemPropertyValue> ItemPropertyValues { get; set; }
    }
}
