using System.Diagnostics;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Output;

#nullable enable

namespace Lingu.CSharpWrite
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
            writer.Block($"namespace {Ctx.Namespace}", () =>
            {
                writer.Using("System");
                writer.Using("System.Diagnostics");
                writer.Using("Lingu.Runtime.Structures");
                Ctx.Space();

                Debug.Assert(Grammar.Symbols != null);

                writer.Class($"public abstract class Abstract{Ctx.VisitorClass}<T> where T : class", () =>
                {
                    foreach (var symbol in Grammar.Symbols)
                    {
                        if (VisitorIgnore(symbol))
                        {
                            continue;
                        }

                        var name = Namer.ToUpperCamelCase(symbol.Name);
                        var type = symbol is Terminal ? "ITerminalToken" : "INonterminalToken";

                        writer.WriteLine($"protected abstract T On{name}({type} token);");

                    }

                    this.writer.WriteLine();

                    writer.Block("protected TAst Visit<TAst>(IToken token) where TAst : T", () =>
                    {
                        this.writer.WriteLine("Debug.Assert(token != null);");
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
                                writer.WriteLine($"{Ctx.IdClass}.{name} => (TAst)On{name}(({type})token),");
                            }
                            writer.WriteLine();
                            writer.WriteLine("_ => throw new NotImplementedException(),");
                        });
                    });

                    this.writer.WriteLine();

                    writer.WriteLine("protected abstract T DefaultOn(IToken token);");
                });

                writer.WriteLine();

                writer.Class($"public abstract class {Ctx.VisitorClass}<T> : Abstract{Ctx.VisitorClass}<T> where T : class", () =>
                {
                    foreach (var symbol in Grammar.Symbols)
                    {
                        if (VisitorIgnore(symbol))
                        {
                            continue;
                        }

                        var name = Namer.ToUpperCamelCase(symbol.Name);
                        var type = symbol is Terminal ? "ITerminalToken" : "INonterminalToken";
                        writer.Block($"protected override T On{name}({type} token)", () =>
                        {
                            this.writer.WriteLine("Debug.Assert(token != null);");
                            this.writer.WriteLine("return DefaultOn(token);");
                        });
                    }
                });

                writer.WriteLine();

                writer.Class($"public static class {Ctx.IdClass}", () =>
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
            });
        }
    }
}
