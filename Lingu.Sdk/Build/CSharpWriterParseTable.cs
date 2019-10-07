using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Build
{
    public class CSharpWriterParseTable : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterParseTable(Grammar grammar, CsWriter writer)
            : base(grammar)
        {
            this.writer = writer;
        }

        public void Write()
        {
            writer.Block($"public static ITable CreateParseTable()", () =>
            {
                Debug.Assert(Grammar.ParseTable != null);

                writer.Data("ushort[] u16Table = ", () =>
                {
                    WriteExtend(writer, Grammar.ParseTable.ReallyAll.Select(entry => (entry.ToString() ?? string.Empty)));
                });

                writer.WriteLine();

                var rows = Grammar.ParseTable.NumberOfStates;
                var nt = Grammar.ParseTable.NumberOfTerminals;
                var cols = Grammar.ParseTable.NumberOfSymbols;

                writer.WriteLine($"return U16ParseTable.From(u16Table, {rows}, {nt}, {cols});");
            });
        }
    }
}
