using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Inverter : IDisposable
    {
        private readonly IObserver _observer;

        public Inverter(IObserver observer)
        {
            _observer = observer;

            _observer.NumbersAddedEvent += Invert;
        }

        public void Dispose()
        {
            _observer.NumbersAddedEvent -= Invert;
        }

        private void Invert(object sender, NumbersEventArgs eventArgs)
        {
            var invertedNumbers = eventArgs.Numbers;

            invertedNumbers.Reverse();

            Console.WriteLine("Inverted numbers:");

            foreach (var number in invertedNumbers) Console.WriteLine(number);
        }
    }
}
