using System.Collections;
using System.Collections.Generic;
using System.Text;
using Lingu.Grammars;

namespace Lingu.LR
{
    public class Item : IReadOnlyList<Symbol>
    {
        private readonly ItemFactory factory;

        public Item(ItemFactory factory, int id, Production production, int dot)
        {
            this.factory = factory;
            Id = id;
            Production = production;
            Dot = dot;
        }

        public Item Next => factory.Get(Production, Dot + 1);

        public int Id { get; }
        public int Dot { get; }
        public Production Production { get; }

        public bool IsComplete => Dot == Count;

        public Symbol PostDot => Dot < Count ? this[Dot] : null;
        public Symbol PreDot => Dot > 0 ? this[Dot - 1] : null;

        public int Count => Production.Count;
        public Symbol this[int index] => Production[index];
        public IEnumerator<Symbol> GetEnumerator() => Production.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object obj) => obj is Item other && Id == other.Id;
        public override int GetHashCode() => Id;

        public override string ToString()
        {
            const string dot = " \u25CF ";

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

            return builder.ToString().TrimEnd();
        }
    }
}