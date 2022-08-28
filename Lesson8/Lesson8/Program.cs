namespace Lesson8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region HomeTask 1

            var director = new DeliveryAddressBuildDirector(new DeliveryAddressBuilder());

            director.CreateAddress();

            Console.WriteLine($"Address: {director.GetAddress().ToString()}");

            #endregion


            #region HomeTask 2

            IObserver observer = new Observer();

            var adder = new Adder(observer);

            var inverter = new Inverter(observer);

            Console.WriteLine("Please enter numbers");

            var numbers = Console.ReadLine();

            observer.SetNumbers(numbers);

            #endregion
        }
    }
}