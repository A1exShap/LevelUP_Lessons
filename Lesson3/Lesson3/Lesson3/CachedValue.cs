using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    internal record CachedValue<T>
    {
        public T? Value { get; set; }

        public DateTime CreationTime { get; set; }

        public int Timeout { get; set; }
    }
}
