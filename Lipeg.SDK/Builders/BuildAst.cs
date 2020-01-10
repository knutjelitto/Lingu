using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Builders
{
    public class BuildAst : IBuildPass
    {
        public BuildAst(INode node)
        {
            Node = node;
            Grammar = new Visitor(this).Visit();
        }

        public INode Node { get; }
        public Grammar Grammar { get; }

        public void Build()
        {
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
                            lexical.AddRange(Lexical(node[i]));
                            break;
                        default:
                            throw new NotImplementedException(); 
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

            private static OptionValue OptionValue(INode node)
            {
                Debug.Assert(node.Name == "option-value");
                return Tree.OptionValue.From(QualifiedIdentifier(node[0]));
            }

            private static Identifier QualifiedIdentifier(INode node)
            {
                Debug.Assert(node.Name == "qualified-identifier");
                return Tree.Identifier.From(node, node.Children.Select(Identifier));
            }

            private static IEnumerable<IRule> Syntax(INode node)
            {
                foreach (var rule in node.Children)
                {
                    yield return Rule(rule);
                }
            }

            private static IEnumerable<IRule> Lexical(INode node)
            {
                foreach (var rule in node.Children)
                {
                    yield return Rule(rule);
                }
            }

            private static Expression Sequence(INode node)
            {
                if (node.Count > 1)
                {
                    var expressions = node.Children.Select(Expression);
                    return SequenceExpression.From(node, expressions);
                }
                return Expression(node[0]);
            }

            private static Expression Choice(INode node)
            {
                if (node.Count > 1)
                {
                    var expressions = node.Children.Select(Expression);
                    return ChoiceExpression.From(node, expressions);
                }
                return Expression(node[0]);
            }

            private static IRule Rule(INode node)
            {
                Debug.Assert(node.Count == 2);

                var id = Identifier(node[0]);
                var ex = Expression(node[1]);
                return Tree.Rule.From(id, ex);
            }

            private static Expression Expression(INode node)
            {
                switch (node.Name)
                {
                    case "sequence": return Sequence(node);
                    case "choice": return Choice(node);
                    case "prefix.drop": return DropExpression.From(node[0], Expression(node[0]));
                    case "prefix.lift": return LiftExpression.From(node[0], Expression(node[0]));
                    case "prefix.fuse": return FuseExpression.From(node[0], Expression(node[0]));
                    case "prefix.not": return NotExpression.From(node[0], Expression(node[0]));
                    case "suffix.zero-or-more": return StarExpression.From(node[0], Expression(node[0]));
                    case "suffix.one-or-more": return PlusExpression.From(node[0], Expression(node[0]));
                    case "suffix.zero-or-one": return OptionalExpression.From(node[0], Expression(node[0]));
                    case "inline": return InlineExpression.From(node[0], Tree.Rule.From(Identifier(node[0]), Expression(node[1])));

                    case "identifier": return NameExpression.From(node, Identifier(node));
                    
                    case "any": return AnyExpression.From(node);
                    case "verbatim-string": return StringLiteralExpression.From(node, ((ILeaf)node).Value);
                    case "character-class": return Class(node);
                    case "string": return String(node);
                    
                    default:
                        throw new NotImplementedException();
                }
            }

            private static Identifier Identifier(INode node)
            {
                Debug.Assert(node.Name == "identifier");
                return Tree.Identifier.From(node, ((ILeaf)node).Value);
            }

            private static StringLiteralExpression String(INode node)
            {
                var builder = new StringBuilder(node.Children.Count());

                foreach (var child in node.Children)
                {
                    var runes = DecodeChar(child);

                    builder.Append(runes);
                }

                return StringLiteralExpression.From(node, builder.ToString());
            }

            private static ClassExpression Class (INode node)
            {
                var parts = new List<ClassPartExpression>();

                foreach (var part in node.Children.Skip(1))
                {
                    switch (part.Name)
                    {
                        case "range":
                            parts.Add(ClassRangeExpression.From(part, 
                                                                Char.ConvertToUtf32(DecodeChar(part[0]), 0), 
                                                                Char.ConvertToUtf32(DecodeChar(part[1]), 0)));
                            break;
                        default:
                            parts.Add(ClassCharExpression.From(part, Char.ConvertToUtf32(DecodeChar(part), 0)));
                            break;
                    }
                }

                return ClassExpression.From(node, node.Children.First().Count != 0, parts);
            }

            private static string DecodeChar(INode node)
            {
                switch (node.Name)
                {
                    case "class-verbatim":
                    case "string-verbatim":
                    case "<any>":
                        return ((ILeaf)node).Value;
                    case "escape":
                        return DecodeEscape((ILeaf)node);
                    case "unicode-escape":
                    case "byte-escape":
                        return System.String.Join(System.String.Empty, node.Children.Select(DecodeHex));
                    default:
                        throw new NotImplementedException();
                }
            }

            private static string DecodeHex(INode node)
            {
                var value = Int32.Parse(((ILeaf) node).Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                return Char.ConvertFromUtf32(value);
            }

            private static string DecodeEscape(ILeaf node)
            {
                switch (node.Value)
                {
                    case "]": return "]";
                    case "-": return "-";
                    case "\"": return "\"";
                    case "\'": return "\'";
                    case "\\": return "\\";

                    case "0": return "\0";
                    case "a": return "\a";
                    case "b": return "\b";
                    case "e": return "\x1b";
                    case "f": return "\f";
                    case "n": return "\n";
                    case "r": return "\r";
                    case "t": return "\t";
                    case "v": return "\v";

                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
