using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Checkers;

namespace Lipeg.SDK.Tree
{
    public class Grammar
    {
        private Grammar(Identifier name, IStarList<Option> options, IStarList<Rule> syntax, IStarList<Rule> lexical)
        {
            Name = name;
            Options = options;
            SyntaxRules = syntax;
            LexicalRules = lexical;
        }

        public Identifier Name { get; }
        public IStarList<Option> Options { get; }
        public IStarList<Rule> SyntaxRules { get; }
        public IStarList<Rule> LexicalRules { get; }
        public IEnumerable<Rule> Rules => SyntaxRules.Concat(LexicalRules);

        public static Grammar From(Identifier name, IStarList<Option> options, IStarList<Rule> syntax, IStarList<Rule> lexicals)
        {
            return new Grammar(name, options, syntax, lexicals);
        }
    }
}
