using System;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Builders;
using Lipeg.SDK.Parsers;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public static class Builder
    {
        public static IParser BuildParser(Grammar grammar)
        {
            if (grammar == null) throw new ArgumentNullException(nameof(grammar));

            Build(grammar.Results, () => new BuildCombinator(grammar));

            var startRule = grammar.Attr.Start;

            var parser = new Name(() => startRule.Attr.Parser, startRule.Identifier);

            grammar.Attr.SetParser(parser);

            return parser;
        }

        public static Grammar BuildAst(INode root)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));

            return new BuildAst(root).Grammar;
        }

        public static void BuildSource(Grammar grammar, FileRef file)
        {
            if (grammar == null) throw new ArgumentNullException(nameof(grammar));
            if (file == null) throw new ArgumentNullException(nameof(file));

            Build(grammar.Results, () => new BuildCSharp(grammar, file));
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
