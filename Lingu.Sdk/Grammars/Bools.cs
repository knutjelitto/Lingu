using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace Lingu.Grammars
{
    public class Bools : IReadOnlyList<bool>
    {
        public Bools(IEnumerable<bool> bools)
        {
            this.bools = bools.ToArray();
        }

        public bool this[int index] => bools[index];
        public int Count => bools.Length;
        public IEnumerator<bool> GetEnumerator() => bools.AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private readonly bool[] bools;

        public override string ToString()
        {
            return string.Join(",", bools.Select(b => b ? "true" : "false"));
        }
    }
}
