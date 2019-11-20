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

            var parser = semantic.Grammar.Attr(semantic).Start.Attr(semantic).Parser;

            if (parser == null)
            {
                throw new InternalErrorException($"{parser} shouldn't be NULL here (should have a parser for start symbol)");
            }

            semantic.Grammar.Attr(semantic).SetParser(parser);
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
