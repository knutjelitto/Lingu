using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Sources;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime
{
    public class LinguContext : IContext
    {
        public LinguContext(IEnumerable<ISymbol> symbols, ParseTable table, Dfa whitespace)
        {
            Symbols = symbols.ToArray();
            Table = table;
            Whitespace = whitespace;

            Debug.Assert(Symbols.Select((terminal, index) => terminal.Id == index).All(b => b));
        }

        public IReadOnlyList<ISymbol> Symbols { get; }
        public ParseTable Table { get; }
        public Dfa Whitespace { get; }

        public void Try(string sourceText)
        {
            var source = new Source("<try>", sourceText);
            var lexer = new Lexer(this, source);
            var parser = new Parser(this, lexer);

            var tree = parser.Parse();
        }
    }
}
