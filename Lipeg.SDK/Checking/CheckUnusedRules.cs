using System;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    /// <summary>
    /// Check if all rules are used
    /// </summary>
    public class CheckUnusedRules : Check, ICheckPass
    {
        public CheckUnusedRules(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
        }
    }
}
