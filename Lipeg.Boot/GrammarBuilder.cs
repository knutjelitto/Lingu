using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA1307 // Specify StringComparison

namespace Lipeg.Boot
{
    internal class GrammarBuilder
    {
        public Grammar Build(INode node)
        {
            Debug.Assert(node.Name == "grammar");

            var identifier = Identifier(node[0]);
            var (options, rules, lexicals) = Content(node[1]);

            return Grammar.From(identifier, options, rules, lexicals);
        }

        private (IList<Option>, IList<IRule>, IList<IRule>) Content(INode node)
        {
            var options = new List<Option>();
            var rules = new List<IRule>();
            var lexical = new List<IRule>();

            foreach (var content in node.Children)
            {
                switch (content.Name)
                {
                    case "options":
                        options.AddRange(Options(content));
                        break;
                    case "syntax":
                        rules.AddRange(Rules(content));
                        break;
                    case "lexical":
                        lexical.AddRange(Rules(content));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return (options, rules, lexical);
        }

        private IEnumerable<Option> Options(INode node)
        {
            Debug.Assert(node.Name == "options");

            return node.Children.Select(Option);
        }

        private Option Option(INode node)
        {
            return SDK.Tree.Option.From(Identifier(node[0]), OptionValue.From(QualifiedIdentifier(node[1])));
        }

        private Identifier Identifier(INode node)
        {
            return SDK.Tree.Identifier.From(node, ((ILeaf) node).Value);
        }

        private Identifier QualifiedIdentifier(INode node)
        {
            Debug.Assert(node.Name == "qualifiedIdentifier");

            var identifiers = node.Children.Select(Identifier).ToPlusList();

            return SDK.Tree.Identifier.From(node, identifiers);
        }

        private IEnumerable<IRule> Rules(INode node)
        {
            Debug.Assert(node.Name == "syntax" || node.Name == "lexical");

            return node.Children.Select(Rule);
        }

        private IRule Rule(INode node)
        {
            var identifier = Identifier(node[0]);
            var expression = Expression(node[1]);

            return SDK.Tree.Rule.From(identifier, expression);
        }

        private Expression Expression(INode node)
        {
            Debug.Assert(node.Name == "choice");

            if (node.Count > 1)
            {
                var choices = node.Children.Select(Sequence);
                return ChoiceExpression.From(node, choices);
            }

            return Sequence(node[0]);

        }

        private Expression Sequence(INode node)
        {
            Debug.Assert(node.Name == "sequence");

            if (node.Count > 1)
            {
                var prefixes = node.Children.Select(Prefix);

                return SequenceExpression.From(node, prefixes);
            }

            return Prefix(node[0]);
        }

        private Expression Prefix(INode node)
        {
            switch (node.Name)
            {
                case "and":
                    return AndExpression.From(node, Suffix(node[0]));
                case "not":
                    return NotExpression.From(node, Suffix(node[0]));
                case "lift":
                    return LiftExpression.From(node, Suffix(node[0]));
                case "drop":
                    return DropExpression.From(node, Suffix(node[0]));
                case "fuse":
                    return FuseExpression.From(node, Suffix(node[0]));
                default:
                    return Suffix(node);
            }
        }

        private Expression Suffix(INode node)
        {
            if (node.Name == "quantified")
            {
                Debug.Assert(node.Count == 2);

                var expression = Primary(node[0]);
                switch (node[1].Name)
                {
                    case "?":
                        return OptionalExpression.From(node, expression);
                    case "*":
                        return StarExpression.From(node, expression);
                    case "+":
                        return PlusExpression.From(node, expression);
                    default:
                        throw new NotImplementedException();
                }
            }

            return Primary(node);
        }

        private Expression Primary(INode node)
        {
            switch (node.Name)
            {
                case "identifier":
                    return NameExpression.From(node, Identifier(node));
                case "singleString":
                case "doubleString":
                    return StringLiteral(node);
                case ".":
                    return AnyExpression.From(node);
                case "choice":
                    return Expression(node);
                case "class":
                    return Class(node);
                case "ε":
                    return EpsilonExpression.From(node);
                case "inline":
                    return InlineExpression.From(node, Rule(node[0]));

                default:
                    throw new NotImplementedException();
            }
        }

        private Expression StringLiteral(INode node)
        {
            switch (node.Name)
            {
                case "doubleString":
                case "singleString":
                    return DoString(node);
                default:
                    throw new NotImplementedException();

            }
        }

        private Expression DoString(INode node)
        {
            Debug.Assert(node.Name == "singleString" || node.Name == "doubleString");
            //Debug.Assert(node[0].Name == "*");

            var characters = string.Join(string.Empty, node.Children.Select(c => Character(c)));

            return SDK.Tree.StringLiteralExpression.From(node, characters);
        }

        private ClassExpression Class(INode node)
        {
            Debug.Assert(node.Name == "class" && node.Count == 2);

            var invert = node[0].Count == 1;
            var ranges = node[1].Children.Select(SingleOrRange).ToArray();

            return ClassExpression.From(node, invert, ranges);
        }

        private ClassPartExpression SingleOrRange(INode node)
        {
            if (node.Name == "single")
            {
                Debug.Assert(node.Count == 1);

                var c = Character(node[0]);
                Debug.Assert(c.Length == 1);
                return ClassCharExpression.From(node, c[0]);
            }
            else if (node.Name == "range")
            {
                Debug.Assert(node.Count == 2);

                var c1 = Character(node[0]);
                Debug.Assert(c1.Length == 1);
                var c2 = Character(node[1]);
                Debug.Assert(c2.Length == 1);
                return ClassRangeExpression.From(node, c1[0], c2[0]);
            }

            throw  new NotImplementedException();
        }

        private string Character(INode node)
        {
            var leaf = (ILeaf) node;

            return leaf.Name switch
            {
                "character" => leaf.Value,
                "simpleEscape" => simpleEscape(leaf.Value),
                "hexEscape" => ((char)int.Parse(leaf.Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture),
                "unicodeEscape" => ((char)int.Parse(leaf.Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture),
                _ => throw new NotImplementedException(),
            };

            static string simpleEscape(string escaped)
            {
                return escaped
                       .Replace("0", "\0")
                       .Replace("a", "\a")
                       .Replace("b", "\b")
                       .Replace("e", "\x1B")
                       .Replace("f", "\f")
                       .Replace("n", "\n")
                       .Replace("r", "\r")
                       .Replace("t", "\t")
                       .Replace("v", "\v");
            }
        }
    }
}
