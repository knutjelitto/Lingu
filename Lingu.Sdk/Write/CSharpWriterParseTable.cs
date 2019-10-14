using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Lingu.Grammars;
using Lingu.Runtime.Commons;
using Lingu.Runtime.Structures;
using Lingu.Writers;
using BinWriter = Lingu.Commons.BinWriter;

#nullable enable

namespace Lingu.Write
{
    public class CSharpWriterParseTable : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterParseTable(CSharpContext ctx)
            : base(ctx)
        {
            this.writer = ctx.Writer;
        }

        public void Write()
        {
            writer.Block($"public static ITable CreateParseTable()", () =>
            {
                Debug.Assert(Grammar.ParseTable != null);

                writer.WriteLine();
                writer.Data("ushort[] u16Table = ", () =>
                {
                    WriteExtend(writer, (Grammar.ParseTable as IParseTable).ReallyAll.Select(entry => (entry.ToString() ?? string.Empty)));
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
