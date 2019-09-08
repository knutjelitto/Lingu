using Lingu.Commons;
using Mean.Maker.Builders;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lingu.Hime
{
    public class Tweaker
    {
        private readonly string inputFile;
        private readonly string outputFile;

        public Tweaker(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
        }

        public void TweakLexer(FileRef lexer)
        {
            var lines = new List<string>();
            foreach (var line in File.ReadAllLines(lexer))
            {
                lines.Add(line.Replace("LinguLexer.bin", "LinguLexer"));
            }
            File.WriteAllLines(lexer, lines);
        }

        public void TweakParser(FileRef lexer)
        {
            var lines = new List<string>();
            foreach (var line in File.ReadAllLines(lexer))
            {
                lines.Add(line.Replace("LinguParser.bin", "LinguParser"));
            }
            File.WriteAllLines(lexer, lines);
        }

        public void TweakVisitor()
        {
            var inlines = File.ReadAllLines(inputFile);
            var outlines = new IWriter();
            
            outlines.WriteLine($"using System;");
            outlines.WriteLine($"using System.Collections.Generic;");
            outlines.WriteLine($"using System.Linq;");
            outlines.WriteLine($"using Hime.Redist;");
            outlines.WriteLine();
            outlines.Block($"namespace {Namespace(inlines)}", () =>
            {
                outlines.Block($"public abstract class {VisitorName()}", () =>
                {
                    outlines.Block($"protected virtual void VisitNode(ASTNode node)", () =>
                    {
                        outlines.WriteLine($"VisitNode<bool>(node);");
                    });

                    outlines.Block($"protected virtual T VisitNode<T>(ASTNode node)", () =>
                    {
                        Switch(inlines, outlines);
                    });

                    outlines.Block($"protected virtual IEnumerable<object> VisitChildren(ASTNode node)", () =>
                    {
                        outlines.Block($"foreach (var child in node.Children)", () =>
                        {
                            outlines.WriteLine($"yield return VisitNode<object>(child);");
                        });
                    });

                    outlines.Block($"protected virtual IEnumerable<T> VisitChildren<T>(ASTNode node)", () =>
                        {
                            outlines.Block($"foreach (var child in node.Children)", () =>
                            {
                                outlines.WriteLine($"yield return VisitNode<T>(child);");
                            });
                        });

                    Virtuals(inlines, outlines);

                    outlines.Block($"partial class OnTerminal", () =>
                    {
                        outlines.Block($"protected OnTerminal({VisitorName()} visitor)", () =>
                        {
                        });
                    });

                    outlines.WriteLine();

                    outlines.Block($"partial class OnVariable", () =>
                    {
                    });

                    outlines.WriteLine();

                    outlines.Block($"partial class OnVirtual", () =>
                    {
                    });
                });
            });

            outlines.Persist(outputFile);
        }

        private void Switch(IReadOnlyList<string> inlines, IWriter outlines)
        {
            var start = 0;
            for (; start < inlines.Count; ++start)
            {
                if (inlines[start] == "\t\t\tswitch(node.Symbol.ID)")
                {
                    break;
                }
            }

            outlines.Block("switch(node.Symbol.ID)", () =>
            {
                for (start += 2; start < inlines.Count; ++start)
                {
                    var line = inlines[start];

                    if (line == "\t\t\t}")
                    {
                        outlines.Indend("default:", () =>
                        {
                            outlines.WriteLine("throw new NotImplementedException();");
                        });
                        break;
                    }

                    line = line.Replace("visitor.", "return (T)");
                    line = line.Replace(" break;", string.Empty);
                    line = line.TrimStart('\t');

                    outlines.WriteLine(line);
                }
            });
        }

        private void Virtuals(IReadOnlyList<string> inlines, IWriter outlines)
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

        private void Virtual(string line, IWriter outlines)
        {
            line = line.Substring(1); // remove '\t'
            line = line.Replace(" {}", string.Empty);
            line = line.Replace("public virtual void", "protected virtual object");
            line = line.TrimStart('\t');
            outlines.Block($"{line}", () =>
            {
                outlines.WriteLine($"return VisitChildren(node).FirstOrDefault();");
            });
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
