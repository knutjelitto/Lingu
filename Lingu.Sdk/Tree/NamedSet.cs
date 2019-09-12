using System;

using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public abstract class NamedSet<TKey, TValue> : UniqueList<TKey, TValue>, ICanDump
        where TKey : Symbol, ICanDump
        where TValue : ICanDump 
    {
        public NamedSet(string setname, bool separate, Func<TValue, TKey> getKey)
            : base(getKey)
        {
            Setname = setname;
            Separate = separate;
        }

        public string Setname { get; }
        public bool Separate { get; }

        public void Dump(IndentWriter output, bool top)
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
