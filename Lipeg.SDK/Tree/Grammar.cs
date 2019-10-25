using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Grammar
    {
        private Grammar(IReadOnlyList<Option> settings, IReadOnlyList<Rule> rules)
        {
            Settings = settings;
            Rules = rules;
        }

        public IEnumerable<Option> Settings { get; }
        public IEnumerable<Rule> Rules { get; }

        public static Grammar From(IReadOnlyList<Option> settings, IReadOnlyList<Rule> rules)
        {
            return new Grammar(settings, rules);
        }
    }
}
