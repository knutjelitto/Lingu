using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Hime.Redist;
using Mean.Language.Generated;

namespace Mean.Language
{
    public static class Checker
    {
        public static void Dump(string source, Func<string, ParseResult> parse)
        {
            var result = parse(source);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error}");
                }
            }
            else
            {
                var dumper = new DumpVisitor();
                dumper.Visit(result);
            }
        }

        public static void DumpTree(string source, Func<string, ParseResult> parse)
        {
            var result = parse(source);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error}");
                }
            }
            else
            {
                PrintTree(result.Root, Array.Empty<bool>());
            }
        }

        public static string Package(string source)
        {
            var lexer = new MeanLexer(source);
            var parser = new MeanParser(lexer);

            var result = parser.Parse();

            if (!result.IsSuccess)
            {
                var errors = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error}");
                    errors.Append($"<<<{error}>>>");
                }

                return errors.ToString();
            }
            else
            {
                Console.WriteLine($"{source} ==> {Tr(result.Root)}");

                return Tr(result.Root);
            }
        }

        public static string Check(string source, Func<string, ParseResult> parse)
        {
            var result = parse(source);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error}");
                }
            }
            else
            {
                Console.WriteLine($"{source} ==> {Tr(result.Root)}");
            }

            return Tr(result.Root);
        }

        public static string Tr(ASTNode node)
        {
            if (node.SymbolType == SymbolType.Terminal)
            {
                return node.Value;
            }

            switch (node.Symbol.Name)
            {
                case "integerLiteral":
                    return Tr(node, 0);
                case "floatLiteral":
                    return Tr(node, 0);
                case "identifier":
                    return Tr(node, 0);

                case "flist": // function alike
                    return $"{Tr(node, 0)}({Tr(node, 1)})";

                case "iselect": // array index alike
                    return $"{Tr(node, 0)}[{Tr(node, 1)}]";
                case "tselect": // tuple field alike
                    return $"{Tr(node, 0)}.{Tr(node, 1)}";
                case "mselect": // member alike
                    return $"{Tr(node, 0)}.{Tr(node, 1)}";

                case "tupleIndex":
                    return Tr(node, 0);

                case "name":
                    if (node.Children.Count == 1)
                    {
                        return Tr(node, 0);
                    }
                    return $"{Tr(node, 0)}<{Tr(node, 1)}>";
                case "genericArgs":
                    return string.Join(",", node.Children.Select(child => Tr(child)));
                case "genericArgsBinding":
                    return $"{Tr(node, 0)}={Tr(node, 1)}";

                case "eqOp":
                    return $"({Tr(node, 0)} == {Tr(node, 1)})";
                case "neOp":
                    return $"({Tr(node, 0)} != {Tr(node, 1)})";

                case "ltOp":
                    return $"({Tr(node, 0)} < {Tr(node, 1)})";

                case "ltltOp":
                    return $"({Tr(node, 0)} < {Tr(node, 1)} < {Tr(node, 2)})";
                case "ltleOp":
                    return $"({Tr(node, 0)} < {Tr(node, 1)} <= {Tr(node, 2)})";

                case "leOp":
                    return $"({Tr(node, 0)} <= {Tr(node, 1)})";

                case "leltOp":
                    return $"({Tr(node, 0)} <= {Tr(node, 1)} < {Tr(node, 2)})";
                case "leleOp":
                    return $"({Tr(node, 0)} <= {Tr(node, 1)} <= {Tr(node, 2)})";

                case "gtOp":
                    return $"({Tr(node, 0)} > {Tr(node, 1)})";

                case "gtgtOp":
                    return $"({Tr(node, 0)} > {Tr(node, 1)} > {Tr(node, 2)})";
                case "gtgeOp":
                    return $"({Tr(node, 0)} > {Tr(node, 1)} >= {Tr(node, 2)})";

                case "geOp":
                    return $"({Tr(node, 0)} >= {Tr(node, 1)})";

                case "gegtOp":
                    return $"({Tr(node, 0)} >= {Tr(node, 1)} > {Tr(node, 2)})";
                case "gegeOp":
                    return $"({Tr(node, 0)} >= {Tr(node, 1)} >= {Tr(node, 2)})";

                case "addOp":
                    return $"({Tr(node, 0)} + {Tr(node, 1)})";

                case "mulOp":
                    return $"({Tr(node, 0)} * {Tr(node, 1)})";

                case "package":
                    {
                        var items = string.Join(";", node.Children.Skip(1).Select(child => Tr(child)));
                        return $"package {Tr(node, 0)} {{ {items} }}";
                    }
                case "type":
                    return Tr(node, 0);

                default:
                    //return $"<<<{node.ToString()}>>>";
                    throw new NotImplementedException(node.ToString());
            }
        }

        public static string Tr(ASTNode node, int index)
        {
            Debug.Assert(index < node.Children.Count);
            return Tr(node.Children[index]);
        }

        private static string MakeLisp(ASTNode node)
        {
            if (node.SymbolType == SymbolType.Terminal)
            {
                return node.Value;
            }
            if (node.Children.Count == 1 && node.Children[0].SymbolType == SymbolType.Terminal)
            {
                return node.Children[0].Value;
            }

            var children = string.Join(" ", node.Children.Select(MakeLisp));
            return $"({node.Symbol} {children})";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
        private static void PrintTree(ASTNode node, bool[] crossings)
        {
            for (var i = 0; i < crossings.Length - 1; i++)
            {
                Console.Write(crossings[i] ? @"|   " : "    ");
            }
            if (crossings.Length > 0)
            {
                Console.Write("+-> ");
            }
            Console.WriteLine(node.ToString());

            for (var i = 0; i != node.Children.Count; i++)
            {
                var childCrossings = new bool[crossings.Length + 1];
                Array.Copy(crossings, childCrossings, crossings.Length);
                childCrossings[childCrossings.Length - 1] = (i < node.Children.Count - 1);
                PrintTree(node.Children[i], childCrossings);
            }
        }
    }
}
