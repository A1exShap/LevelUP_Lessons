namespace DataAccess.DTO
{
    public partial class Item
    {
        public Item()
        {
            ItemPropertyValues = new HashSet<ItemPropertyValue>();
        }

        public Guid Id { get; set; }
        public Guid ItemType { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ItemType ItemTypes { get; set; } = null!;
        public virtual ICollection<ItemPropertyValue> ItemPropertyValues { get; set; }
    }
}
