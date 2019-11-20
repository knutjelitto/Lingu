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
            Check(semantic.Results, () => new CheckIsUsedRules(semantic));
            Check(semantic.Results, () => new CheckIsReachableRules(semantic));
            Check(semantic.Results, () => new CheckIsNullable(semantic));
            Check(semantic.Results, () => new CheckManySanity(semantic));
            Check(semantic.Results, () => new CheckIsLexical(semantic));
            Check(semantic.Results, () => new CheckParentRules(semantic));
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
