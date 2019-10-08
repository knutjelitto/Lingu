using System.Diagnostics;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Write
{
    public class CSharpWriterVisitor : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterVisitor(CSharpContext ctx)
            : base(ctx)
        {
            this.writer = ctx.Writer;
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
                    var type = symbol is Terminal ? "ITerminalToken" : "INonterminalToken";

                    writer.WriteLine($"public abstract W On{name}<W>({type} token) where W : T;");

                }

                this.writer.WriteLine();

                writer.Block("protected W Visit<W>(IToken token) where W : T", () =>
                {
                    this.writer.Data("return token.Symbol.Id switch", () =>
                    {
                        foreach (var symbol in Grammar.Symbols)
                        {
                            if (VisitorIgnore(symbol))
                            {
                                continue;
                            }

                            var name = Namer.ToUpperCamelCase(symbol.Name);
                            var type = symbol is Terminal ? "ITerminalToken" : "INonterminalToken";
                            writer.WriteLine($"Id.{name} => On{name}<W>(({type})token),");
                        }
                        writer.WriteLine();
                        writer.WriteLine("_ => throw new NotImplementedException(),");
                    });
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
                    var type = symbol is Terminal ? "ITerminalToken" : "INonterminalToken";
                    writer.WriteLine($"public override W On{name}<W>({type} token) {{ return Default<W>(token); }}");
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
