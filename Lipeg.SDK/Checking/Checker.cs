﻿using System;

using Lipeg.Runtime;

namespace Lipeg.SDK.Checking
{
    public static class Checker
    {
        public static void Check(Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            Check(semantic.Results, () => new CheckCreateRules(semantic));
            Check(semantic.Results, () => new CheckDefined(semantic));
            Check(semantic.Results, () => new CheckUnusedRules(semantic));
        }

        private static void Check(ICompileResult results, Func<ICheckPass> pass)
        {
            if (!results.ShouldStop)
            {
                pass().Check();
            }
        }
    }
}
