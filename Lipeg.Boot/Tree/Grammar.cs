using System;
using System.Collections.Generic;
using System.Text;
using Pegasus.Common;

namespace Lipeg.Boot.Tree
{
    public class Grammar
    {
        private Grammar(IEnumerable<Rule> rules, IEnumerable<Setting> settings, Cursor end)
        {
            Rules = rules;
            Settings = settings;
            End = end;
        }

        public IEnumerable<Rule> Rules { get; }
        public IEnumerable<Setting> Settings { get; }
        public Cursor End { get; }

        public static Grammar From(IEnumerable<Rule> rules, IEnumerable<Setting> settings, Cursor end)
        {
            return new Grammar(rules, settings, end);
        }
    }
}
