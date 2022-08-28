using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Adder : IDisposable
    {
        private readonly IObserver _observer;

        public Adder(IObserver observer)
        {
            _observer = observer;

            _observer.NumbersAddedEvent += Sum;
        }

        public void Dispose()
        {
            _observer.NumbersAddedEvent -= Sum;
        }

        private void Sum(object sender, NumbersEventArgs eventArgs)
            => Console.WriteLine($"SUM: {eventArgs.Numbers.Sum()}");

    }
}
