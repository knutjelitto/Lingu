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

        private (IStarList<Option>, IStarList<Rule>, IStarList<Rule>) Content(INode node)
        {
            var options = new List<Option>();
            var rules = new List<Rule>();
            var lexical = new List<Rule>();

            foreach (var content in node)
            {
                switch (content.Name)
                {
                    case "options":
                        options.AddRange(Options(content));
                        break;
                    case "rules":
                        rules.AddRange(Rules(content));
                        break;
                    case "lexical":
                        lexical.AddRange(Rules(content));
                        break;
                }
            }

            return (options.ToStarList(), rules.ToStarList(), lexical.ToStarList());
        }

        private IEnumerable<Option> Options(INode node)
        {
            Debug.Assert(node.Name == "options");

            return node.Select(Option);
        }

        private Option Option(INode node)
        {
            return SDK.Tree.Option.From(Identifier(node[0]), QualifiedIdentifier(node[1]));
        }

        private Identifier Identifier(INode node)
        {
            return SDK.Tree.Identifier.From(node.Location, ((ILeafNode) node).Value);
        }

        private QualifiedIdentifier QualifiedIdentifier(INode node)
        {
            Debug.Assert(node.Name == "qualifiedIdentifier");

            var identifiers = node.Select(Identifier).ToPlusList();

            return SDK.Tree.QualifiedIdentifier.From(node, identifiers);
        }

        private IEnumerable<Rule> Rules(INode node)
        {
            Debug.Assert(node.Name == "rules" || node.Name == "lexical");

            return node.Select(Rule);
        }

        private Rule Rule(INode node)
        {
            var identifier = Identifier(node[0]);
            var expression = Expression(node[1]);

            return SDK.Tree.Rule.From(identifier, expression);
        }

        private Expression Expression(INode node)
        {
            Debug.Assert(node.Name == "choice");

            var choices = node.Select(Sequence).ToPlusList();

            return ChoiceExpression.From(node, choices);
        }

        private Expression Sequence(INode node)
        {
            Debug.Assert(node.Name == "sequence");

            var aliased = node.Select(Aliased).ToStarList();

            return SequenceExpression.From(node, aliased);
        }

        private Expression Aliased(INode node)
        {
            if (node.Name == "alias")
            {
                var expression = Expression(node[0]);
                var identifier = Identifier(node[1]);

                return AliasExpression.From(node, expression, identifier);
            }

            return Prefix(node);
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
                return QuantifiedExpression.From(node, Primary(node[0]), Quantifier(node[1]));
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
                    return WildcardExpression.From(node);
                case "choice":
                    return Expression(node);
                case "class":
                    return Class(node);

                default:
                    throw new NotImplementedException();
            }
        }

        private Quantifier Quantifier(INode node)
        {
            switch (node.Name)
            {
                case "?":
                    return SDK.Tree.Quantifier.From(node.Location, 0, 1);
                case "*":
                    return SDK.Tree.Quantifier.From(node.Location, 0, null);
                case "+":
                    return SDK.Tree.Quantifier.From(node.Location, 1, null);
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

            var characters = string.Join(string.Empty, node.Select(c => Character(c)));

            return SDK.Tree.StringLiteralExpression.From(node, characters);
        }

        private ClassExpression Class(INode node)
        {
            Debug.Assert(node.Name == "class" && node.Count == 2);

            var invert = node[0].Count == 1;
            var ranges = node[1].Select(SingleOrRange).ToArray();

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
            var leaf = (ILeafNode) node;

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
