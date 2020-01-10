using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Common;

namespace Lipeg.SDK.Tree
{
    public class Grammar
    {
        private Grammar(Identifier name, IList<Option> options, IList<IRule> syntax, IList<IRule> lexical)
        {
            Name = name;
            Options = options;
            SyntaxRules = syntax;
            LexicalRules = lexical;
        }

        public Identifier Name { get; }
        public IList<Option> Options { get; }
        public IList<IRule> SyntaxRules { get; }
        public IList<IRule> LexicalRules { get; }
        public IEnumerable<IRule> AllRules => SyntaxRules.Concat(LexicalRules);

        public IGrammarAttributes Attr { get; } = new GrammarAttributes();
        public ICompileResult Results { get; } = new CompileResult();

        public static Grammar From(Identifier name, IList<Option> options, IList<IRule> syntax, IList<IRule> lexicals)
        {
            return new Grammar(name, options, syntax, lexicals);
        }
    }
}
