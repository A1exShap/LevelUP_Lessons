namespace Lesson2.SportGoods
{
    public class Food : GoodsBase, IHasShelfLife
    {
        public DateTime ProductionDate { get; init; }
        public int ShelfLife { get; init; }
        public bool IsValid { get; set; }

        public Food(string name, string description, DateTime productionDate, int shelfLife) : base(name, description)
        {
            ProductionDate = productionDate;
            ShelfLife = shelfLife;
        }
    }
}
