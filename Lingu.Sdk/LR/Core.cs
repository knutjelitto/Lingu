using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class Core : IReadOnlyList<Symbol>
    {
        private readonly CoreFactory factory;

        public Core(CoreFactory factory, int id, Production production, int dot)
        {
            this.factory = factory;
            Id = id;
            Production = production;
            Dot = dot;
        }

        public Core Next => factory.Get(Production, Dot + 1);

        public int Id { get; }
        public int Dot { get; }
        public Production Production { get; }

        public bool IsComplete => Dot == Count;
        public bool IsInitial => Dot == 0;

        public Symbol PostDot => this[Dot];
        public Symbol PreDot => this[Dot - 1];

        public int Count => Production.Count;
        public Symbol this[int index] => Production[index];
        public IEnumerator<Symbol> GetEnumerator() => Production.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object? obj) => obj is Core other && Id == other.Id;
        public override int GetHashCode() => Id.GetHashCode();

        public string LHStoString()
        {
            return $"{Production.Nonterminal}";
        }

        public string RHStoString()
        {
            //const string dotter = "◦"; // \u25E6
            //const string dotter = "•"; // \u2022
            //const string dotter = "●"; // \u25CF
            const string dotter = "♦"; // \u2666

            var builder = new StringBuilder();

            var items = Production
                .Take(Dot).Select(p => p.ToString())
                .Concat(Enumerable.Repeat(dotter, 1))
                .Concat(Production.Skip(Dot).Select(p => p.ToString()));


            var more = false;
            foreach (var item in items)
            {
                if (more)
                {
                    builder.Append(" ");
                }
                builder.Append(item);
                more = true;
            }

            return builder.ToString();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(LHStoString());
            builder.Append(" -> ");
            builder.Append(RHStoString());

            return builder.ToString();
        }
    }
}