using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public interface IObserver
    {
        delegate void NumbersEventHandler(object sender, NumbersEventArgs eventArgs);

        event NumbersEventHandler? NumbersAddedEvent;

        void SetNumbers(string numbers);
    }
}
