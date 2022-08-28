using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Observer : IObserver
    {
        private List<int> _numbers;

        public delegate void NumbersEventHandler(object sender, NumbersEventArgs eventArgs);

        public event IObserver.NumbersEventHandler? NumbersAddedEvent;

        public void SetNumbers(string numbersStr)
        {
            int num;

            _numbers = new List<int>();

            foreach (var item in numbersStr.Split(' '))
            {
                if (int.TryParse(item, out num)) _numbers.Add(num);
            }

            if (_numbers.Count > 0) RaiseEvent(_numbers);
        }

        public virtual void RaiseEvent(List<int> numbers)
        {
            NumbersAddedEvent?.Invoke(this, new NumbersEventArgs(numbers));
        }
    }
}
