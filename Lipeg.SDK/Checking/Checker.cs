using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using System;

namespace Lipeg.SDK.Checking
{
    public static class Checker
    {
        public static void Check(Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            Check(semantic, () => new CheckDefineRules());
            Check(semantic, () => new CheckDefined());
            Check(semantic, () => new CheckUnusedRules());
        }

        private static void Check(Semantic semantic, Func<ICheckPass> pass)
        {
            if (!semantic.Results.ShouldStop)
            {
                pass().Check(semantic);
            }
        }
    }
}
