using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lipeg.Runtime
{
    public class Option<T> : IOption<T>
    {
        private T[] list;

        public Option(IEnumerable<T> list)
        {
            this.list = list.ToArray();
            Debug.Assert(this.list.Length >= 0 && this.list.Length <= 1);
        }

        public T this[int index] => list[index];
        public int Count => list.Length;

        public IEnumerator<T> GetEnumerator() => list.AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
