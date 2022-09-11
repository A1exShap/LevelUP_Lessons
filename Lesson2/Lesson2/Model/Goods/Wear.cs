namespace Lesson2.SportGoods
{
    public class Wear : GoodsBase
    {
        public WearSize WearSize { get; init; }

        public Wear(int goodsType, string name, string description, WearSize wearSize) : base(goodsType, name, description)
        {
            WearSize = wearSize;
        }
    }
}
