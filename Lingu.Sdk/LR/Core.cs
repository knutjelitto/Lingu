using System.Collections;
using System.Collections.Generic;
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

        public override string ToString()
        {
            //const string dot = " ◦ "; // \u25E6
            //const string dot = " • "; // \u2022
            //const string dot = " ● "; // \u25CF
            const string dot = " ♦ "; // \u2666

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
                builder.Append(dot).Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }
    }
}