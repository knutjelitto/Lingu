using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class Grammar
    {
        private Grammar(Identifier name, IStarList<Option> options, IStarList<Rule> syntax, IStarList<Rule> lexical)
        {
            Name = name;
            Options = options;
            Syntax = syntax;
            Lexical = lexical;
        }

        public Identifier Name { get; }
        public IStarList<Option> Options { get; }
        public IStarList<Rule> Syntax { get; }
        public IStarList<Rule> Lexical { get; }
        public IEnumerable<Rule> Rules => Syntax.Concat(Lexical);

        public static Grammar From(Identifier name, IStarList<Option> options, IStarList<Rule> syntax, IStarList<Rule> lexicals)
        {
            return new Grammar(name, options, syntax, lexicals);
        }
    }
}
