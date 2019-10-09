using System.Collections.Generic;

using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Write
{
    public class CSharpWriterTools
    {
        protected const int extendWidth = 120;

        public CSharpWriterTools(CSharpContext ctx)
        {
            Ctx = ctx;
        }

        public CSharpContext Ctx { get; }
        protected Grammar Grammar => Ctx.Grammar;

        protected string Bool(bool b) => b ? "true" : "false";

        protected bool VisitorIgnore(Symbol symbol)
        {
            return symbol.Name.StartsWith("__") ||
                   symbol is Terminal terminal && terminal.IsFragment ||
                   symbol is Nonterminal nonterminal && (nonterminal.IsPrivate || nonterminal.IsLift);
        }

        protected void WriteExtend(IndentWriter writer, IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                if (writer.Extend() > 0)
                {
                    writer.Write(" ");
                }
                writer.Write($"{value},");
                if (writer.Extend() >= extendWidth)
                {
                    writer.WriteLine();
                }
            }
            if (writer.Extend() > 0 && writer.Extend() < extendWidth)
            {
                writer.WriteLine();
            }
        }

        protected void WriteMany(IndentWriter writer, int perLine, IEnumerable<string> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                writer.Write($"{value},");
                count += 1;
                if (count == perLine)
                {
                    writer.WriteLine();
                    count = 0;
                }
            }
            if (count > 0)
            {
                writer.WriteLine();
            }
        }
    }
}
