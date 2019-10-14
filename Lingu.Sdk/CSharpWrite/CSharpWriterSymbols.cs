using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.Runtime.Concretes;
using Lingu.Runtime.Structures;
using Lingu.Output;

#nullable enable

namespace Lingu.CSharpWrite
{
    public class CSharpWriterSymbols : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterSymbols(CSharpContext ctx)
            : base(ctx)
        {
            this.writer = ctx.Writer;
        }

        public void Write()
        {
            Debug.Assert(Grammar.Symbols != null);

            var terminalType = nameof(TerminalSymbol);
            var nonterminalType = nameof(NonterminalSymbol);

            foreach (var symbol in Grammar.Symbols)
            {
                if (symbol is Terminal terminal)
                {
                    writer.Write($"public static readonly {terminalType} {terminal.Name} = ");
                    writer.WriteLine($"new {terminalType}({terminal.Id}, \"{terminal.Name}\", {Bool(terminal.IsVisible)}, \"{terminal.Visual}\");");
                }
                else if (symbol is Nonterminal nonterminal)
                {
                    writer.Write($"public static readonly {nonterminalType} {nonterminal.Name} = ");
                    writer.WriteLine($"new {nonterminalType}({nonterminal.Id}, \"{nonterminal.Name}\", {Bool(nonterminal.IsPrivate)}, {nameof(RepeatKind)}.{nonterminal.Repeat});");
                }
            }

            writer.WriteLine();

            writer.Data("public static readonly Symbol[] Symbols = ", () =>
            {
                WriteExtend(writer, Grammar.Symbols.Select(symbol => symbol.Name));
            });
        }
    }
}
