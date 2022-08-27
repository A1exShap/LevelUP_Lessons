namespace Lesson7
{
    public class SquareRootCalculator
    {
        private readonly IEnumerable<int> _range;

        public SquareRootCalculator(IEnumerable<int> range)
        {
            _range = range;
        }

        public void CalcRun()
        {
            Parallel.ForEach(_range, Calc);
        }

        private void Calc(int num)
        {
            Console.WriteLine($"Square root of {num}: {Math.Sqrt(num)}");
        }
    }
}
