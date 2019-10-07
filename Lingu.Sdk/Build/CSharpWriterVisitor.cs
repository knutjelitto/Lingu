using System.Diagnostics;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Build
{
    public class CSharpWriterVisitor : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterVisitor(Grammar grammar, CsWriter writer)
            : base(grammar)
        {
            this.writer = writer;
        }

        public void Write()
        {
            Debug.Assert(Grammar.Symbols != null);

            writer.Class("public abstract class AbstractVisitor<T>", () =>
            {
                foreach (var symbol in Grammar.Symbols)
                {
                    if (VisitorIgnore(symbol))
                    {
                        continue;
                    }

                    var name = Namer.ToUpperCamelCase(symbol.Name);

                    writer.WriteLine($"public abstract W On{name}<W>(IToken token) where W : T;");

                }

                this.writer.WriteLine();

                writer.Block("protected W Visit<W>(IToken token) where W : T", () =>
                {
                    this.writer.Block("switch (token.Symbol.Id)", () =>
                    {
                        foreach (var symbol in Grammar.Symbols)
                        {
                            if (VisitorIgnore(symbol))
                            {
                                continue;
                            }

                            var name = Namer.ToUpperCamelCase(symbol.Name);
                            writer.WriteLine($"case Id.{name}: return On{name}<W>(token);");
                        }
                    });

                    writer.WriteLine();
                    writer.WriteLine("throw new System.NotImplementedException();");
                });

                this.writer.WriteLine();

                writer.WriteLine("protected abstract W Default<W>(IToken token) where W : T;");
            });

            writer.WriteLine();

            writer.Class("public abstract class Visitor<T> : AbstractVisitor<T>", () =>
            {
                foreach (var symbol in Grammar.Symbols)
                {
                    if (VisitorIgnore(symbol))
                    {
                        continue;
                    }

                    var name = Namer.ToUpperCamelCase(symbol.Name);
                    writer.WriteLine($"public override W On{name}<W>(IToken token) {{ return Default<W>(token); }}");
                }
            });

            writer.WriteLine();

            writer.Class("public class Id", () =>
            {
                foreach (var symbol in Grammar.Symbols)
                {
                    if (VisitorIgnore(symbol))
                    {
                        continue;
                    }

                    var name = Namer.ToUpperCamelCase(symbol.Name);
                    writer.WriteLine($"public const int {name} = {symbol.Id};");
                }
            });
        }
    }
}
