using Lesson2.SportGoods;

namespace Lesson2.Controller
{
    public class ShelfLifeProvider
    {
        private List<IHasShelfLife> _hasShelfLivesGoods;

        public ShelfLifeProvider()
        {
            _hasShelfLivesGoods = new List<IHasShelfLife>();
        }

        public bool Add(IHasShelfLife goods)
        {
            try
            {
                CheckShelfLife(goods);
                _hasShelfLivesGoods.Add(goods);

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Check() => _hasShelfLivesGoods.ForEach(CheckShelfLife);

        private void CheckShelfLife(IHasShelfLife goods)
        {
            var diff = (DateTime.Now - goods.ProductionDate).TotalDays;

            goods.IsValid = diff < goods.ShelfLife;
        }
    }
}