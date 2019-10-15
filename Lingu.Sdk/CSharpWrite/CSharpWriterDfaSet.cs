using System;
using System.Diagnostics;
using System.Linq;

using Lingu.Build;
using Lingu.Commons;
using Lingu.Output;
using Lingu.Runtime.Commons;

#nullable enable

namespace Lingu.CSharpWrite
{
    public class CSharpWriterDfaSet : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterDfaSet(CSharpContext ctx)
            : base(ctx)
        {
            this.writer = ctx.Writer;
        }

        public void Write()
        {
            writer.Block($"public static {Ctx.DfaSetType} CreateDfaSet()", () =>
            {
                var compact = new CompactDfaWriter(Grammar);

                var bytes = compact.Write();

                writer.WriteLine($"// {bytes.Length} bytes");
                var compress = new CompressWriter().Compress(bytes);
                writer.WriteLine($"// compressed {compress.Length} bytes");
                var uncompress = new CompressReader().Uncompress(compress);
                writer.WriteLine($"// uncompress {uncompress.Length} bytes");
                Debug.Assert(bytes.SequenceEqual(uncompress));

                writer.Data("var bytes = new byte[]", () =>
                {
                    WriteExtend(writer, compress.Select(b => b.ToString()));
                });

                writer.WriteLine();
                
                writer.WriteLine($"return new CompactDfaReader(new BinReader(new CompressReader().Uncompress(bytes))).Read();");
            });
        }
    }
}
