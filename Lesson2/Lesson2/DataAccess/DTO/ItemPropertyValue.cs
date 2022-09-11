using System;
using System.Collections.Generic;

namespace DataAccess.DTO
{
    public partial class ItemPropertyValue
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Guid ItemId { get; set; }
        public string? StringValue { get; set; }
        public decimal? NumericValue { get; set; }
        public Guid? EnumValueId { get; set; }

        public virtual PropertyEnumValue? EnumValue { get; set; }
        public virtual Item Item { get; set; } = null!;
        public virtual ItemProperty Property { get; set; } = null!;
    }
}
