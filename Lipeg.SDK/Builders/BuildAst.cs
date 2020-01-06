using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Parsers;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Builders
{
    public class BuildAst : IBuildPass
    {
        public BuildAst(ICompileResult result, INode node)
        {
            Result = result;
            Node = node;
        }

        public ICompileResult Result { get; }
        public INode Node { get; }

        public void Build()
        {
            new Visitor(this).Visit();
        }

        private class Visitor
        {
            public Visitor(BuildAst buildAst)
            {
                BuildAst = buildAst;
            }

            public BuildAst BuildAst { get; }
            public INode Root => BuildAst.Node;

            public Grammar Visit()
            {
                Debug.Assert(Root.Name == "start" && Root.Count == 2);

                return Grammar(Root[0]);
            }

            private static Grammar Grammar(INode node)
            {
                Debug.Assert(node.Name == "grammar" && node.Count >= 1);

                var options = new List<Option>();
                var syntax = new List<IRule>();
                var lexical = new List<IRule>();

                for (var i = 1; i < node.Count; ++i)
                {
                    switch (node[i].Name)
                    {
                        case "options":
                            options.AddRange(Options(node[i]));
                            break;
                        case "syntax":
                            syntax.AddRange(Syntax(node[i]));
                            break;
                        case "lexical":
                            syntax.AddRange(Lexical(node[i]));
                            break;
                    }
                }

                return Tree.Grammar.From(Identifier(node[0]), options, syntax, lexical);
            }

            private static IEnumerable<Option> Options(INode node)
            {
                foreach (var option in node.Children)
                {
                    yield return Option(option);
                }
            }

            private static Option Option(INode node)
            {
                return Tree.Option.From(Identifier(node[0]), OptionValue(node[1]));
            }

            private static Identifier Identifier(INode node)
            {
                return Tree.Identifier.From(node, node.Name);
            }

            private static OptionValue OptionValue(INode node)
            {
                return Tree.OptionValue.From(QualifiedIdentifier(node));
            }

            private static Identifier QualifiedIdentifier(INode node)
            {
                return Tree.Identifier.From(node, node.Children.Select(Identifier));
            }

            private static IEnumerable<Rule> Syntax(INode node)
            {
                foreach (var rule in node.Children)
                {
                    yield return Rule(rule);
                }
            }

            private static IEnumerable<Rule> Lexical(INode node)
            {
                foreach (var rule in node.Children)
                {
                    yield return Rule(rule);
                }
            }

            private static Rule Rule(INode node)
            {
                throw new NotImplementedException();
            }
        }
    }
}
