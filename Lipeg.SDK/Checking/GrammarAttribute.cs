using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;

namespace Lipeg.SDK.Checking
{
    internal class GrammarAttribute : IGrammarAttribute
    {
        private readonly List<IRule> start = new List<IRule>();
        private readonly List<IRule> spacing = new List<IRule>();

        public IRule Start => start.First();
        public IRule Spacing => spacing.First();
    }
}
