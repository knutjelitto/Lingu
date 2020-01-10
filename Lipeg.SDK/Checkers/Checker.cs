using System;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public static class Checker
    {
        public static void Check(Grammar grammar)
        {
            if (grammar == null) throw new ArgumentNullException(nameof(grammar));

            Check(grammar.Results, () => new CheckCreateRules(grammar));
            Check(grammar.Results, () => new CheckUndefinedRules(grammar));
            Check(grammar.Results, () => new CheckOptions(grammar));
            Check(grammar.Results, () => new CheckIsUsedRules(grammar));
            Check(grammar.Results, () => new CheckIsReachableRules(grammar));
            Check(grammar.Results, () => new CheckIsNullable(grammar));
            Check(grammar.Results, () => new CheckManySanity(grammar));
            Check(grammar.Results, () => new CheckIsLexical(grammar));
            Check(grammar.Results, () => new CheckParentRules(grammar));
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
