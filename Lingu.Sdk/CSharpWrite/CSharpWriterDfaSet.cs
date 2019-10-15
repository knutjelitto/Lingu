using Lingu.Build;
using Lingu.Commons;
using Lingu.Output;

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

                var bytes = new CompressWriter().Compress(compact.Write());

                WriteByteArray("byte[] bytes = ", bytes);

                writer.WriteLine();
                
                writer.WriteLine($"return new CompactDfaReader(new BinReader(new CompressReader().Uncompress(bytes))).Read();");
            });
        }
    }
}
