using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Lingu.Grammars;
using Lingu.Runtime.Commons;
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

                var bytes = Blob.ToCompressedBytes(Grammar.ParseTable.ReallyAll.Select(e => e.Coded));
                //var bytes2 = Blob.ToBytes2(Grammar.ParseTable.ReallyAll.Select(e => e.Coded));

                writer.Data("byte[] compressedTable = ",
                () =>
                {
                    WriteExtend(writer, bytes.AsEnumerable().Select(b => b.ToString()));
                });

#if true
                writer.WriteLine();
                writer.Data("ushort[] u16Table = ", () =>
                {
                    WriteExtend(writer, Grammar.ParseTable.ReallyAll.Select(entry => (entry.ToString() ?? string.Empty)));
                });
#endif

                writer.WriteLine();

                var rows = Grammar.ParseTable.NumberOfStates;
                var nt = Grammar.ParseTable.NumberOfTerminals;
                var cols = Grammar.ParseTable.NumberOfSymbols;

#if true
                writer.WriteLine($"return U16ParseTable.From(u16Table, {rows}, {nt}, {cols});");
#else
                this.writer.WriteLine($"var ushorts = Blob.UInt16FromBytes({bytes.Length}, {rows * cols}, compressedTable);");
                writer.WriteLine($"return U16ParseTable.From(ushorts, {rows}, {nt}, {cols});");
#endif
            });
        }
    }
}
