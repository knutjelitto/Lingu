using System;

using Lipeg.Runtime;

namespace Lipeg.SDK.Checkers
{
    public static class AChecker
    {
        public static void Check(Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            Check(semantic.Results, () => new CheckCreateRules(semantic));
            Check(semantic.Results, () => new CheckUndefinedRules(semantic));
            Check(semantic.Results, () => new CheckOptions(semantic));
            Check(semantic.Results, () => new CheckUsedRules(semantic));
            Check(semantic.Results, () => new CheckReachableRules(semantic));
            Check(semantic.Results, () => new CheckNullable(semantic));
            Check(semantic.Results, () => new CheckManySanity(semantic));
            Check(semantic.Results, () => new CheckIsLexical(semantic));
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
