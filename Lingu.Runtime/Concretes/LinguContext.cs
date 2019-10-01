using System.Collections.Generic;
using System.Linq;
using Lingu.Runtime.Errors;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Sources;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class LinguContext : IContext
    {
        public LinguContext(IEnumerable<ISymbol> symbols, IEnumerable<IProduction> productions, ParseTable table, Dfa common, Dfa whitespace)
        {
            Symbols = symbols.ToArray();
            Productions = productions.ToArray();
            Table = table;
            Common = common;
            Whitespace = whitespace;
            Errors = new ErrorHandler(this);
        }

        public IReadOnlyList<ISymbol> Symbols { get; }
        public IReadOnlyList<IProduction> Productions { get; }
        public ParseTable Table { get; }
        public Dfa Common { get; }
        public Dfa Whitespace { get; }

        public IErrorHandler Errors { get; }

        public INonterminalToken Try(Source source)
        {
            var lexer = new Lexer(this, source);
            var parser = new Parser(this, lexer);

            var tree = parser.Parse();

            return tree;
        }
    }
}
