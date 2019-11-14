using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    internal class GrammarAttribute : IGrammarAttributes
    {
        private readonly List<Rule> start = new List<Rule>();
        private readonly List<Rule> spacing = new List<Rule>();
        private readonly List<IParser> parser = new List<IParser>();

        public Rule Start => start.First();
        public Rule Spacing => spacing.First();
        public IParser Parser => parser.First();

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

        public bool SetParser(IParser parser)
        {
            if (this.parser.Count == 0)
            {
                this.parser.Add(parser);
                return true;
            }
            return false;
        }
    }
}
