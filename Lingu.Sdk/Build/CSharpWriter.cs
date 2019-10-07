using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Build
{
    [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
    public class CSharpWriter : CSharpWriterTools
    {
        public CSharpWriter(Grammar grammar)
            : base(grammar)
        {
        }

        public void Build(DirRef output)
        {
            const string @namespace = "Lingu.CC";

            var ctx = new CSharpContext(Grammar);


            var writer = new CsWriter();
            writer.Block($"namespace {@namespace}", () =>
            {
                writer.Using("System.Linq");
                writer.Using("Lingu.Runtime.Concretes");
                writer.Using("Lingu.Runtime.Lexing");
                writer.Using("Lingu.Runtime.Parsing");
                writer.Using("Lingu.Runtime.Structures");
                writer.WriteLine();

                writer.Block($"public partial class {ctx.ContextClass}", () =>
                {
                    writer.Block($"public static class {ctx.DataSubClass}", () =>
                    {
                        new CSharpWriterDfaSet(Grammar, writer).Write();

                        writer.WriteLine();

                        new CSharpWriterParseTable(Grammar, writer).Write();

                        writer.WriteLine();

                        new CSharpWriterSymbols(Grammar, writer).Write();

                        writer.WriteLine();

                        new CSharpWriterProductions(Grammar, writer).Write();
                    });
                });
            });
            writer.Persist(output.WithFile($"{ctx.ContextClass}.{ctx.DataSubClass}.cs"));

            
            writer = new CsWriter();
            writer.Block($"namespace {@namespace}", () =>
            {
                writer.Using("Lingu.Runtime.Concretes");
                writer.Using("Lingu.Runtime.Lexing");
                writer.Using("Lingu.Runtime.Parsing");
                writer.Using("Lingu.Runtime.Structures");
                writer.WriteLine();

                writer.Block($"public partial class {ctx.ContextClass}", () =>
                {
                    Debug.Assert(Grammar.Symbols != null);

                    writer.Block("public static IContext CreateContext()", () =>
                    {

                    });

                });
            });
            writer.Persist(output.WithFile($"{ctx.ContextClass}.cs"));


            writer = new CsWriter();
            writer.Block($"namespace {@namespace}", () =>
            {
                writer.Using("System");
                writer.Using("Lingu.Runtime.Concretes");
                writer.Using("Lingu.Runtime.Lexing");
                writer.Using("Lingu.Runtime.Parsing");
                writer.Using("Lingu.Runtime.Structures");
                writer.WriteLine();

                writer.Block($"public class {ctx.VisitorClass}", () =>
                {
                    new CSharpWriterVisitor(Grammar, writer).Write();
                });
            });

            writer.Persist(output.WithFile($"{ctx.VisitorClass}.cs"));

        }
    }
}
