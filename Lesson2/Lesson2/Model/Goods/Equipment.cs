namespace Lesson2.SportGoods
{
    public sealed class Equipment : GoodsBase
    {
        public EquipmentType EquipmentType { get; init; }

        public Equipment(int goodsType, string name, string description, EquipmentType equipmentType) : base(goodsType, name, description)
        {
            EquipmentType = equipmentType;
        }
    }
}
