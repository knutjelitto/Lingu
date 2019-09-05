using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lingu.Commons;

namespace Lingu.Tree
{
    public abstract class NamedSet<T> : IndexedList<string, T>, IDumpable
        where T : INamed, IDumpable
    {
        public NamedSet(string setname, bool separate)
            : base(item => item.Name.Text)
        {
            Setname = setname;
            Separate = separate;
        }

        public string Setname { get; }
        public bool Separate { get; }

        public void Dump(IWriter output, bool top)
        {
            output.Block(Setname, () =>
            {
                var more = false;
                foreach (var item in this)
                {
                    if (Separate && more) output.WriteLine();
                    item.Dump(output, top);
                    more = true;
                }
            });
        }

    }
}
