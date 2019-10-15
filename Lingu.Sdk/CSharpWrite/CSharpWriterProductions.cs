using System.Linq;

using Lingu.Grammars;
using Lingu.Output;

#nullable enable

namespace Lingu.CSharpWrite
{
    public class CSharpWriterProductions : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterProductions(CSharpContext ctx)
            : base(ctx)
        {
            this.writer = ctx.Writer;
        }

        public void Write()
        {
            writer.Data("private static readonly Production[] productions = ", () =>
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
