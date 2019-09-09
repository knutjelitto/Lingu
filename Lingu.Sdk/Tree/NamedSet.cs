using System;

using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public abstract class NamedSet<TKey, TValue> : UniqueList<TKey, TValue>, IDumpable
        where TKey : Symbol, IDumpable
        where TValue : IDumpable 
    {
        public NamedSet(string setname, bool separate, Func<TValue, TKey> getKey)
            : base(getKey)
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
