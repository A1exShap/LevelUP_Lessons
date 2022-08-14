namespace Lesson2.SportGoods
{
    public abstract class GoodsBase
    {
        protected GoodsBase(string name, string description)
        {
            Article = Guid.NewGuid();

            Name = name;
            Description = description;
        }

        public Guid Article { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}