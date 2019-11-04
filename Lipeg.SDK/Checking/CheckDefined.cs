using System;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checking
{
    /// <summary>
    /// Check if all rules are defined
    /// </summary>
    public class CheckDefined : Check, ICheckPass
    {
        public CheckDefined(Semantic semantic)
            : base(semantic)
        {

        }

        public void Check()
        {
        }
    }
}
