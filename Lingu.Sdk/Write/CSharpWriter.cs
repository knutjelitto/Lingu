using System.Diagnostics;

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
            WriteContext(Ctx.WithWriter());
            WriteData(Ctx.WithWriter());
            WriteVisitor(Ctx.WithWriter());
        }

        private void WriteContext(CSharpContext ctx)
        {
            ctx.Writer.Block($"namespace {ctx.Namespace}", () =>
            {
                ctx.Writer.Using("Lingu.Runtime.Structures");
                ctx.Space();

                ctx.Writer.Block($"public partial class {ctx.ContextClass}", () =>
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
            ctx.Writer.Persist(ctx.Output.File($"{ctx.ContextClass}.cs"));
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

                ctx.Writer.Block($"public partial class {ctx.ContextClass}", () =>
                {
                    ctx.Writer.Block($"public static class {ctx.DataSubClass}", () =>
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
            ctx.Writer.Persist(ctx.Output.File($"{ctx.ContextClass}.{ctx.DataSubClass}.cs"));
        }

        private void WriteVisitor(CSharpContext ctx)
        {
            ctx.Writer.Block($"namespace {ctx.Namespace}", () =>
            {
                ctx.Writer.Using("System");
                ctx.Writer.Using("Lingu.Runtime.Structures");
                ctx.Space();

                ctx.Writer.Block($"public class {ctx.VisitorClass}", () =>
                {
                    new CSharpWriterVisitor(ctx).Write();
                });
            });

            ctx.Writer.Persist(ctx.Output.File($"{ctx.VisitorClass}.cs"));
        }
    }
}
