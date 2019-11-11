using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    internal class GrammarAttribute : IGrammarAttributes
    {
        private readonly List<Rule> start = new List<Rule>();
        private readonly List<Rule> spacing = new List<Rule>();

        public Rule Start => start.First();
        public Rule Spacing => spacing.First();

        public bool SetStart(Rule rule)
        {
            if (start.Count == 0)
            {
                start.Add(rule);
                return true;
            }
            return false;
        }

        public bool SetSpacing(Rule rule)
        {
            if (spacing.Count == 0)
            {
                spacing.Add(rule);
                return true;
            }
            return false;
        }
    }
}
