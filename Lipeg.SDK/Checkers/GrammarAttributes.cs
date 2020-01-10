using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    internal class GrammarAttributes : IGrammarAttributes
    {
        private readonly List<IRule> start = new List<IRule>();
        private readonly List<IRule> spacing = new List<IRule>();
        private readonly List<IParser> parser = new List<IParser>();

        public GrammarAttributes()
        {
            Rules = new UniqueCollection<string, IRule>(r => r.Identifier.Name, StringComparer.OrdinalIgnoreCase);
        }

        public UniqueCollection<string, IRule> Rules { get; }

        public IRule Start => start.First();
        public IRule Spacing => spacing.First();
        public IParser Parser => parser.First();

        public bool SetStart(IRule rule)
        {
            if (start.Count == 0)
            {
                start.Add(rule);
                return true;
            }
            return false;
        }

        public bool SetSpacing(IRule rule)
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
