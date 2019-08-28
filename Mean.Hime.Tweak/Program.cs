using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mean.Hime.Tweak
{
    public class Program
    {
        private readonly string inputFile;
        private readonly string outputFile;

        static void Main(string[] args)
        {
            var program = new Program(args[0], args[1]);
            program.Process();
        }

        public Program(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
        }

        public void Process()
        {
            var inlines = File.ReadAllLines(inputFile);
            var outlines = new List<string>();
            outlines.Add($"using System;");
            outlines.Add($"using System.Collections.Generic;");
            outlines.Add($"using System.Linq;");
            outlines.Add($"using Hime.Redist;");
            outlines.Add($"");
            outlines.Add($"namespace {Namespace(inlines)}");
            outlines.Add($"{{");

            outlines.Add($"\tpublic abstract class {VisitorName()}");
            outlines.Add($"\t{{");

            outlines.Add($"\t\tprotected virtual void VisitNode(ASTNode node)");
            outlines.Add($"\t\t{{");
            outlines.Add($"\t\t\tVisitNode<bool>(node);");
            outlines.Add($"\t\t}}");
            outlines.Add($"");

            outlines.Add($"\t\tprotected virtual T VisitNode<T>(ASTNode node)");
            outlines.Add($"\t\t{{");
            Switch(inlines, outlines);
            outlines.Add($"\t\t}}");
            outlines.Add($"");

            outlines.Add($"\t\tprotected virtual IEnumerable<object> VisitChildren(ASTNode node)");
            outlines.Add($"\t\t{{");
            outlines.Add($"\t\t\tfor (var i = 0; i < node.Children.Count; i++)");
            outlines.Add($"\t\t\t{{");
            outlines.Add($"\t\t\t\tyield return VisitNode<object>(node.Children[i]);");
            outlines.Add($"\t\t\t}}");
            outlines.Add($"\t\t}}");

            outlines.Add($"\t\tprotected virtual IEnumerable<T> VisitChildren<T>(ASTNode node)");
            outlines.Add($"\t\t{{");
            outlines.Add($"\t\t\tfor (var i = 0; i < node.Children.Count; i++)");
            outlines.Add($"\t\t\t{{");
            outlines.Add($"\t\t\t\tyield return VisitNode<T>(node.Children[i]);");
            outlines.Add($"\t\t\t}}");
            outlines.Add($"\t\t}}");

            outlines.Add($"");

            Virtuals(true, inlines, outlines);

            outlines.Add($"\t}}");

            outlines.Add($"}}");

            File.WriteAllLines(outputFile, outlines);
        }

        private void Switch(IReadOnlyList<string> inlines, IList<string> outlines)
        {
            var start = 0;
            for (; start < inlines.Count; ++start)
            {
                if (inlines[start] == "\t\t\tswitch(node.Symbol.ID)")
                {
                    break;
                }
            }

            for (; start < inlines.Count; ++start)
            {
                var line = inlines[start];
                    
                if (line == "\t\t\t}")
                {
                    outlines.Add("\t\t\t\tdefault:");
                    outlines.Add("\t\t\t\t\tthrow new NotImplementedException();");
                    outlines.Add(line);
                    break;
                }

                line = line.Replace("visitor.", "return (T)");
                line = line.Replace(" break;", string.Empty);

                outlines.Add(line);
            }
        }

        private void Virtuals(bool @void, IReadOnlyList<string> inlines, IList<string> outlines)
        {
            var start = 0;
            for (; start < inlines.Count; ++start)
            {
                if (inlines[start] == "\t\tpublic class Visitor")
                {
                    break;
                }
            }

            start = start + 2;

            for (; start < inlines.Count; ++start)
            {
                var line = inlines[start];

                if (line == "\t\t}")
                {
                    break;
                }

                Virtual(line, outlines);
            }
        }

        private void Virtual(string line, IList<string> outlines)
        {
            line = line.Substring(1); // remove '\t'
            line = line.Replace(" {}", string.Empty);
            line = line.Replace("public virtual void", "public virtual object");
            outlines.Add($"{line}");
#if true
            outlines.Add($"\t\t{{");
            outlines.Add($"\t\t\treturn VisitChildren(node).FirstOrDefault();");
            outlines.Add($"\t\t}}");
#endif
        }

        private string Namespace(IReadOnlyCollection<string> lines)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("namespace"))
                {
                    return line.Substring("namespace ".Length);
                }
            }

            throw new ArgumentOutOfRangeException(nameof(lines));
        }

        private string ParserName()
        {
            return Path.GetFileNameWithoutExtension(inputFile);
        }

        private string VisitorName()
        {
            var name = ParserName();

            return name.Substring(0, name.Length - "Parser".Length) + "Visitor";
        }
    }
}
