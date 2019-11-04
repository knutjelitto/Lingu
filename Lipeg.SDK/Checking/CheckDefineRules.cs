using System;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    /// <summary>
    /// Check if all rules are defined
    /// </summary>
    internal class CheckDefineRules : ICheckPass
    {
        public void Check(Semantic semantic)
        {
            foreach (var rule in semantic.Grammar.Rules)
            {

            }
        }
    }
}
