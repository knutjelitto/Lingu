using System.Diagnostics;
using System.Xml.Xsl;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Write
{
    public class CSharpWriter : CSharpWriterTools
    {
        public CSharpWriter(Grammar grammar, DirRef output)
            : base(new CSharpContext(grammar, "Lingu.CC", output))
        {
        }

        public void Write()
        {
            var ctx = Ctx.WithWriter();
            WriteContext(ctx);
            ctx.Writer.Persist(Ctx.ContextClassFile);

            ctx = Ctx.WithWriter();
            WriteData(ctx);
            ctx.Writer.Persist(Ctx.DataSubClassFile);

            ctx = Ctx.WithWriter();
            WriteVisitor(ctx);
            ctx.Writer.Persist(Ctx.VisitorClassFile);
        }

        private void WriteContext(CSharpContext ctx)
        {
            ctx.Writer.Block($"namespace {ctx.Namespace}", () =>
            {
                ctx.Writer.Using("Lingu.Runtime.Structures");
                ctx.Space();

                ctx.Writer.Block($"public static partial class {ctx.ContextClass}", () =>
                {
                    Debug.Assert(ctx.Grammar.Symbols != null);

                    ctx.Writer.Block("public static IContext CreateContext()", () =>
                    {
                        ctx.Writer.Write("return new Lingu.Runtime.Concretes.LinguContext(");
                        ctx.Writer.Write("Data.Symbols, ");
                        ctx.Writer.Write("Data.Productions, ");
                        ctx.Writer.Write("Data.CreateParseTable(), ");
                        ctx.Writer.WriteLine("Data.CreateDfaSet());");
                    });
                });
            });
        }

        private void WriteData(CSharpContext ctx)
        {
            ctx.Writer.Block($"namespace {ctx.Namespace}", () =>
            {
                ctx.Writer.Using("System");
                ctx.Writer.Using("System.Linq");
                ctx.Writer.Using("Lingu.Runtime.Commons");
                ctx.Writer.Using("Lingu.Runtime.Concretes");
                ctx.Writer.Using("Lingu.Runtime.Lexing");
                ctx.Writer.Using("Lingu.Runtime.Parsing");
                ctx.Writer.Using("Lingu.Runtime.Structures");
                ctx.Space();

                ctx.Writer.Block($"public static partial class {ctx.ContextClass}", () =>
                {
                    ctx.Writer.Block($"internal static class {ctx.DataSubClass}", () =>
                    {
                        new CSharpWriterDfaSet(ctx).Write();
                        ctx.Space();
                        new CSharpWriterParseTable(ctx).Write();
                        ctx.Space();
                        new CSharpWriterSymbols(ctx).Write();
                        ctx.Space();
                        new CSharpWriterProductions(ctx).Write();
                    });
                });
            });
        }

        private void WriteVisitor(CSharpContext ctx)
        {
            new CSharpWriterVisitor(ctx).Write();

            ctx.Writer.Persist(ctx.VisitorClassFile);
        }
    }
}
