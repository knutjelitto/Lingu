using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Grammar
    {
        private Grammar(Identifier name, IReadOnlyList<Option> settings, IReadOnlyList<Rule> rules)
        {
            Name = name;
            Settings = settings;
            Rules = rules;
        }

        public Identifier Name { get; }
        public IEnumerable<Option> Settings { get; }
        public IEnumerable<Rule> Rules { get; }

        public static Grammar From( Identifier name, IReadOnlyList<Option> settings, IReadOnlyList<Rule> rules)
        {
            return new Grammar(name, settings, rules);
        }
    }
}
