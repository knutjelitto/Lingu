using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Grammars
{
    public class Drops : IReadOnlyList<bool>
    {
        public Drops(IEnumerable<bool> drops)
        {
            this.drops = drops.ToArray();
        }

        public bool this[int index] => drops[index];
        public int Count => drops.Length;
        public IEnumerator<bool> GetEnumerator() => drops.AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private readonly bool[] drops;
    }
}
