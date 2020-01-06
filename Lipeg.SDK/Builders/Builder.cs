using System;

using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Builders;
using Lipeg.SDK.Parsers;

namespace Lipeg.SDK.Checkers
{
    public static class Builder
    {
        public static void BuildParser(Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            Build(semantic.Results, () => new BuildCombinator(semantic));

            var startRule = semantic.Grammar.Attr(semantic).Start;

            var parser = new Name(() => startRule.Attr(semantic).Parser, startRule.Identifier);

            semantic.Grammar.Attr(semantic).SetParser(parser);
        }

        public static void BuildAst(ICompileResult result, INode root)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (root == null) throw new ArgumentNullException(nameof(root));

            Build(result, () => new BuildAst(result, root));
        }

        public static void BuildSource(Semantic semantic, FileRef file)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));
            if (file == null) throw new ArgumentNullException(nameof(file));

            Build(semantic.Results, () => new BuildCSharp(semantic, file));
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
