using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Lingu.Grammars;
using Lingu.Output;

#nullable enable

namespace Lingu.CSharpWrite
{
    public class CSharpWriterTools
    {
        protected const int extendWidth = 150;

        public CSharpWriterTools(CSharpContext ctx)
        {
            Ctx = ctx;
        }

        public CSharpContext Ctx { get; }
        protected Grammar Grammar => Ctx.Grammar;
        protected CsWriter Writer => Ctx.Writer;

        protected string Bool(bool b) => b ? "true" : "false";

        protected bool VisitorIgnore(Symbol symbol)
        {
            return symbol.Name.StartsWith("__") ||
                   symbol is Terminal terminal && terminal.IsFragment ||
                   symbol is Nonterminal nonterminal && (nonterminal.IsPrivate || nonterminal.IsLift);
        }

        protected void WriteByteArray(string head, IEnumerable<byte> bytes)
        {
            Writer.Data(head, () =>
            {
                WriteExtend(bytes.Select(b => b.ToString()));
            });

        }

        protected void WriteExtend(IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                Writer.Write($"{value},");
                if (Writer.Extend() >= extendWidth)
                {
                    Writer.WriteLine();
                }
            }
            if (Writer.Extend() > 0 && Writer.Extend() < extendWidth)
            {
                Writer.WriteLine();
            }
        }

        protected void WriteMany(int perLine, IEnumerable<string> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                Writer.Write($"{value},");
                count += 1;
                if (count == perLine)
                {
                    Writer.WriteLine();
                    count = 0;
                }
            }
            if (count > 0)
            {
                Writer.WriteLine();
            }
        }
    }
}
