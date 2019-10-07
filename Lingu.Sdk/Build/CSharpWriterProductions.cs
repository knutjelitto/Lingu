using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.Runtime.Concretes;
using Lingu.Runtime.Structures;
using Lingu.Writers;

#nullable enable

namespace Lingu.Build
{
    public class CSharpWriterProductions : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterProductions(Grammar grammar, CsWriter writer)
            : base(grammar)
        {
            this.writer = writer;
        }

        public void Write()
        {
            writer.Data("public static readonly Production[] Productions = ", () =>
            {
                foreach (var production in Grammar.Productions)
                {
                    var drops = string.Join(", ", production.Drops.Select(Bool));
                    var visual = production.ToString();
                    var sep = drops.Length > 0 ? ", " : string.Empty;
                    var ip = Bool(production.IsPromote);
                    writer.WriteLine($"new Production({production.Nonterminal.Name}, {ip}, \"{visual}\"{sep}{drops}),");
                }
            });
        }
    }
}
