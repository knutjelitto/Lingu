using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Checkers;

namespace Lipeg.SDK.Tree
{
    public class Grammar
    {
        private Grammar(Identifier name, IList<Option> options, IList<Rule> syntax, IList<Rule> lexical)
        {
            Name = name;
            Options = options;
            SyntaxRules = syntax;
            LexicalRules = lexical;
        }

        public Identifier Name { get; }
        public IList<Option> Options { get; }
        public IList<Rule> SyntaxRules { get; }
        public IList<Rule> LexicalRules { get; }
        public IEnumerable<Rule> Rules => SyntaxRules.Concat(LexicalRules);

        public static Grammar From(Identifier name, IList<Option> options, IList<Rule> syntax, IList<Rule> lexicals)
        {
            return new Grammar(name, options, syntax, lexicals);
        }
    }
}
