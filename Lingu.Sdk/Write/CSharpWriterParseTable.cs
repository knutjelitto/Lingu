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

                var binWriter = new BinWriter();
                foreach (var coded in Grammar.ParseTable.ReallyAll.Select(entry => entry.Coded))
                {
                    binWriter.Write(coded);
                }
                var bytes = binWriter.ToArray();
                var memory = new MemoryStream();
                var deflate = new DeflateStream(memory, CompressionLevel.Optimal);
                deflate.Write(bytes);
                deflate.Close();
                var compressed = memory.ToArray();

                writer.Data("byte[] compressedTable = ",
                () =>
                {
                    WriteExtend(writer, Blob.ToBytes(Grammar.ParseTable.ReallyAll.Select(e => e.Coded)).AsEnumerable().Select(b => b.ToString()));
                });

#if false
                writer.Data("ushort[] u16Table = ", () =>
                {
                    WriteExtend(writer, Grammar.ParseTable.ReallyAll.Select(entry => (entry.ToString() ?? string.Empty)));
                });
#endif

                writer.WriteLine();

                var rows = Grammar.ParseTable.NumberOfStates;
                var nt = Grammar.ParseTable.NumberOfTerminals;
                var cols = Grammar.ParseTable.NumberOfSymbols;

                this.writer.WriteLine($"var ushorts = Blob.UInt16FromBytes({bytes.Length}, {rows * cols}, compressedTable);");
                writer.WriteLine($"return U16ParseTable.From(ushorts, {rows}, {nt}, {cols});");
            });
        }
    }
}
