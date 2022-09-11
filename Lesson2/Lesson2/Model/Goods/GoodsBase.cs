namespace Lesson2.SportGoods
{
    public abstract class GoodsBase
    {
        protected GoodsBase(int goodsType, string name, string description)
        {
            Id = Guid.NewGuid();
            GoodsType = goodsType;
            Name = name;
            Description = description;
        }

        public Guid Id { get; init; }

        public int GoodsType { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }
    }
}