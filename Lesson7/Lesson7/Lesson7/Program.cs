namespace Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> range = Enumerable.Range(1, 100);

            var squareRootCalculator = new SquareRootCalculator(range);
            squareRootCalculator.CalcRun();

            Concatenator.Concat();
        }
    }
}