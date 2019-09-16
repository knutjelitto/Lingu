using System.Collections;
using System.Collections.Generic;
using System.Text;
using Lingu.Grammars;

namespace Lingu.LR
{
    public class LR0Item : IReadOnlyList<ProdSymbol>
    {
        private readonly ItemFactory factory;

        public LR0Item(ItemFactory factory, Production production, int dot)
        {
            this.factory = factory;
            Production = production;
            Dot = dot;
        }

        public LR0Item Next => this.factory.Get(Production, Dot + 1);

        public int Dot { get; }
        public Production Production { get; }

        public bool IsComplete => Dot == Count;

        public ProdSymbol PostDot => Dot < Count ? this[Dot] : null;
        public ProdSymbol PreDot => Dot > 0 ? this[Dot - 1] : null;

        public override bool Equals(object obj)
        {
            return obj is LR0Item other && Dot.Equals(other.Dot) && Production.Equals(other.Production);
        }

        public override int GetHashCode()
        {
            return (Production, Dot).GetHashCode();
        }

        public IEnumerator<ProdSymbol> GetEnumerator() => Production.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => Production.Count;

        public ProdSymbol this[int index] => Production[index];

        public override string ToString()
        {
            const string dot = "\u25CF";

            var builder = new StringBuilder();

            builder.Append($"{Production.Nonterminal} ->");

            for (var p = 0; p < Production.Count; p++)
            {
                builder.AppendFormat(
                    "{0}{1}",
                    p == Dot ? dot : " ",
                    Production[p]);
            }

            if (Dot == Production.Count)
            {
                builder.Append(dot);
            }

            return builder.ToString();
        }
    }
}