using System.Collections.Generic;
using System.Linq;

using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Nonterminal : Rule
    {
        private readonly List<Production> productions;

        public Nonterminal(string name)
            : base(name)
        {
            productions = new List<Production>();
        }

        public bool IsEmbedded { get; set; }

        public IReadOnlyList<Production> Productions => productions;

        public void AddProductions(params IEnumerable<Symbol>[] symbols)
        {
            productions.AddRange(symbols.Select(s => new Production(this, s)));
        }

        public override void Dump(IndentWriter writer, bool top)
        {
            writer.Indend($"{Name}", () =>
            {
                bool more = false;
                foreach (var production in Productions)
                {
                    if (more)
                    {
                        writer.Write("| ");
                    }
                    else
                    {
                        writer.Write(": ");
                    }
                    more = true;

                    writer.WriteLine(string.Join(" ", production));
                }
                writer.WriteLine(";");
            });
        }
    }
}
