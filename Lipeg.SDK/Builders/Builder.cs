using System;

using Lipeg.Runtime;
using Lipeg.SDK.Builders;

namespace Lipeg.SDK.Checkers
{
    public static class Builder
    {
        public static void Build(Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            Build(semantic.Results, () => new BuildCombinator(semantic));
        }

        private static void Build(ICompileResult results, Func<IBuildPass> pass)
        {
            if (!results.HasErrors)
            {
                pass().Build();
            }
        }
    }
}
