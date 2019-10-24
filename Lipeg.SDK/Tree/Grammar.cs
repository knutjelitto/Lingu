using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Grammar
    {
        private Grammar(IReadOnlyList<Setting> settings, IReadOnlyList<Rule> rules)
        {
            Settings = settings;
            Rules = rules;
        }

        public IEnumerable<Setting> Settings { get; }
        public IEnumerable<Rule> Rules { get; }

        public static Grammar From(IReadOnlyList<Setting> settings, IReadOnlyList<Rule> rules)
        {
            return new Grammar(settings, rules);
        }
    }
}
