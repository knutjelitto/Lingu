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
        public LinguContext(IEnumerable<ISymbol> symbols, IEnumerable<IProduction> productions, ITable table, IDfaSet dfas)
        {
            Symbols = symbols.ToArray();
            Productions = productions.ToArray();
            Table = table;
            Dfas = dfas;
            Errors = new ErrorHandler(this);
        }

        public IReadOnlyList<ISymbol> Symbols { get; }
        public IReadOnlyList<IProduction> Productions { get; }
        public ITable Table { get; }
        public IDfaSet Dfas { get; }
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
