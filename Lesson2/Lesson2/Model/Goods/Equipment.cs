namespace Lesson2.SportGoods
{
    public sealed class Equipment : GoodsBase
    {
        public EquipmentType EquipmentType { get; init; }

        public Equipment(string name, string description, EquipmentType equipmentType) : base(name, description)
        {
            EquipmentType = equipmentType;
        }
    }
}
