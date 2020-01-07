using System;
using System.Threading;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Builders;
using Lipeg.SDK.Parsers;
using Lipeg.SDK.Tree;

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

        public static Grammar BuildAst(ICompileResult result, INode root)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));
            if (root == null) throw new ArgumentNullException(nameof(root));

            return new BuildAst(result, root).Grammar;
        }

        public static void BuildSource(Semantic semantic, FileRef file)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));
            if (file == null) throw new ArgumentNullException(nameof(file));

            Build(semantic.Results, () => new BuildCSharp(semantic, file));
        }

        private static T? Build<T>(ICompileResult results, Func<T> newPass) where T : class, IBuildPass
        {
            if (!results.HasErrors)
            {
                var pass = newPass();
                pass.Build();

                return pass;
            }

            return null;
        }
    }
}
