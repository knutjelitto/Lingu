using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;

namespace Lipeg.SDK.Checks
{
    internal class GrammarAttribute : IGrammarAttribute
    {
        private readonly List<IRule> start = new List<IRule>();
        private readonly List<IRule> spacing = new List<IRule>();

        public IRule Start => start.First();
        public IRule Spacing => spacing.First();

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
    }
}
