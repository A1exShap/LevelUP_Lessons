namespace Lesson2.SportGoods
{
    public class Wear : GoodsBase
    {
        public WearSize WearSize { get; init; }

        public Wear(string name, string description, WearSize wearSize) : base(name, description)
        {
            WearSize = wearSize;
        }
    }
}
