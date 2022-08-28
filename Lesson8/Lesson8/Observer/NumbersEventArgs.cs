namespace Lesson8
{
    public class NumbersEventArgs
    {
        public NumbersEventArgs(List<int> numbers)
        {
            Numbers = numbers;
        }

        public List<int> Numbers { get; }
    }
}
