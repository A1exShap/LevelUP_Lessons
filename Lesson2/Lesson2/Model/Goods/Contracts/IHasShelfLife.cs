namespace Lesson2.SportGoods
{
    public interface IHasShelfLife
    {
        public DateTime ProductionDate { get; init; }

        public int ShelfLife { get; init; }

        public bool IsValid { get; set; }
    }
}
