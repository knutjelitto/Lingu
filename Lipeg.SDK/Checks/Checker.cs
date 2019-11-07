using System;

using Lipeg.Runtime;

namespace Lipeg.SDK.Checks
{
    public static class Checker
    {
        public static void Check(Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            Check(semantic.Results, () => new CheckCreateRules(semantic));
            Check(semantic.Results, () => new CheckDefinedRules(semantic));
            Check(semantic.Results, () => new CheckOptions(semantic));
            Check(semantic.Results, () => new CheckUnusedRules(semantic));
            Check(semantic.Results, () => new CheckNullable(semantic));
        }

        private static void Check(ICompileResult results, Func<ICheckPass> pass)
        {
            if (!results.HasErrors)
            {
                pass().Check();
            }
        }
    }
}
