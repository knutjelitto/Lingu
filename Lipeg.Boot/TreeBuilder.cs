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

            return Grammar.From(Options(node[0]), Rules(node[1]));
        }

        private IReadOnlyList<Option> Options(INode node)
        {
            Debug.Assert(node.Name == "options");

            return node[0].Select(Option).ToList();
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

            var identifiers = node[0].Select(Identifier).ToList();

            return SDK.Tree.QualifiedIdentifier.From(identifiers);
        }

        private IReadOnlyList<Rule> Rules(INode node)
        {
            Debug.Assert(node.Name == "rules");

            return node[0].Select(Rule).ToList();
        }

        private Rule Rule(INode node)
        {
            var identifier = Identifier(node[0]);
            var flags = node[1].Select(Identifier).ToList();
            var expression = Expression(node[2]);

            return SDK.Tree.Rule.From(identifier, flags, expression);
        }

        private Expression Expression(INode node)
        {
            Debug.Assert(node.Name == "choice");

            var choices = node[0].Select(Sequence).ToList();

            return ChoiceExpression.From(choices);
        }

        private Expression Sequence(INode node)
        {
            Debug.Assert(node.Name == "sequence");

            var labeled = node[0].Select(Labeled).ToList();

            return SequenceExpression.From(labeled);
        }

        private Expression Labeled(INode node)
        {
            if (node.Name == "labeled")
            {
                return LabeledExpression.From(Identifier(node[0]), Prefix(node[1]));
            }

            return Prefix(node);
        }

        private Expression Prefix(INode node)
        {
            if (node.Name == "and")
            {
                return AndExpression.From(Suffix(node[0]));
            }
            if (node.Name == "not")
            {
                return NotExpression.From(Suffix(node[0]));
            }

            return Suffix(node);
        }

        private Expression Suffix(INode node)
        {
            if (node.Name == "quantified")
            {
                Debug.Assert(node.Count == 2);
                return Quantified.From(Primary(node[0]), Quantifier(node[1]));
            }

            return Primary(node);
        }

        private Expression Primary(INode node)
        {
            switch (node.Name)
            {
                case "identifier":
                    return NameExpression.From(Identifier(node));
                case "singleString":
                case "doubleString":
                    return StringLiteral(node);
                case ".":
                    return WildcardExpression.From();
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
            Debug.Assert(node[0].Name == "*");

            var characters = string.Join(string.Empty, node[0].Select(c => Character(c)));

            return SDK.Tree.StringLiteral.From(node.Location, characters);
        }

        private ClassExpression Class(INode node)
        {
            Debug.Assert(node.Name == "class" && node.Count == 2);

            var ranges = node[0].Select(SingleOrRange).ToList();
            var invert = node[1].Count == 1;

            return ClassExpression.From(ranges, invert);
        }

        private CharExpression SingleOrRange(INode node)
        {
            if (node.Name == "single")
            {
                Debug.Assert(node.Count == 1);

                var c = Character(node[0]);
                Debug.Assert(c.Length == 1);
                return SDK.Tree.Character.From(c[0]);
            }
            else if (node.Name == "range")
            {
                Debug.Assert(node.Count == 2);

                var c1 = Character(node[0]);
                Debug.Assert(c1.Length == 1);
                var c2 = Character(node[1]);
                Debug.Assert(c2.Length == 1);
                return CharacterRange.From(c1[0], c2[0]);
            }

            throw  new NotImplementedException();
        }

        private string Character(INode node)
        {
            var leaf = (ILeafNode) node;

            return leaf.Name switch
            {
                "simpleCharacter" => leaf.Value,
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
