using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Output;
using Lingu.Build;
using Lingu.Commons;
using Lingu.Runtime.Commons;

#nullable enable

namespace Lingu.CSharpWrite
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
            writer.Block($"public static {Ctx.ParseTableType} CreateParseTable()", () =>
            {
                Debug.Assert(Grammar.ParseTable != null);

                var compact = new CompactTableWriter(Grammar.ParseTable);

                var bytes = compact.Write();

                writer.WriteLine($"// {bytes.Length} bytes");
                var compress = new CompressWriter().Compress(bytes);
                writer.WriteLine($"// compressed {compress.Length} bytes");
                var uncompress = new CompressReader().Uncompress(compress);
                writer.WriteLine($"// uncompress {uncompress.Length} bytes");
                Debug.Assert(bytes.SequenceEqual(uncompress));

                writer.Data("byte[] bytes = ", () =>
                {
                    WriteExtend(writer, compress.Select(b => b.ToString()));
                });

                writer.WriteLine();

                writer.WriteLine($"return new CompactTableReader(new BinReader(new CompressReader().Uncompress(bytes))).Read();");
            });
        }
    }
}
