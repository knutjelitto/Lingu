using Lipeg.Runtime;
using System;

namespace Lipeg.SDK.Checking
{
    public static class Checker
    {
        public static void Check(ICompileResult result)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));

            Check(result, () => new CheckDefined()); ;
            Check(result, () => new CheckUnusedRules());
        }

        private static void Check(ICompileResult result, Func<ICheckPass> pass)
        {
            if (!result.ShouldStop)
            {
                pass().Check(result);
            }
        }
    }
}
