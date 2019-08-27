﻿using Mean.Maker;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lingu.Bootstrap
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

        public void Tweak()
        {
            var inlines = File.ReadAllLines(inputFile);
            var outlines = new Indentable();
            
            outlines.Add($"using System;");
            outlines.Add($"using System.Collections.Generic;");
            outlines.Add($"using System.Linq;");
            outlines.Add($"using Hime.Redist;");
            outlines.Add($"");
            outlines.Add($"namespace {Namespace(inlines)}");
            using (outlines.Indent())
            {
                outlines.Add($"public abstract class {VisitorName()}");
                using (outlines.Indent())
                {
                    outlines.Block($"protected virtual void VisitNode(ASTNode node)", () =>
                    {
                        outlines.Add($"VisitNode<bool>(node);");
                    });

                    outlines.Block($"protected virtual T VisitNode<T>(ASTNode node)", () =>
                    {
                        Switch(inlines, outlines);
                    });

                    outlines.Block($"protected virtual IEnumerable<object> VisitChildren(ASTNode node)", () =>
                    {
                        outlines.Block($"foreach (var child in node.Children)", () =>
                        {
                            outlines.Add($"yield return VisitNode<object>(child);");
                        });
                    });

                    outlines.Block($"protected virtual IEnumerable<T> VisitChildren<T>(ASTNode node)", () =>
                        {
                            outlines.Block($"foreach (var child in node.Children)", () =>
                            {
                                outlines.Add($"yield return VisitNode<T>(child);");
                            });
                        });

                    Virtuals(inlines, outlines);

                    outlines.Add($"partial class OnTerminal");
                    using (outlines.Indent())
                    {
                        outlines.Add($"protected OnTerminal({VisitorName()} visitor)");
                        using (outlines.Indent())
                        {
                        }
                    }

                    outlines.Add($"");

                    outlines.Add($"partial class OnVariable");
                    using (outlines.Indent())
                    {
                    }

                    outlines.Add($"");

                    outlines.Add($"partial class OnVirtual");
                    using (outlines.Indent())
                    {
                    }
                }
            }

            outlines.Persist(outputFile);
        }

        private void Switch(IReadOnlyList<string> inlines, Indentable outlines)
        {
            var start = 0;
            for (; start < inlines.Count; ++start)
            {
                if (inlines[start] == "\t\t\tswitch(node.Symbol.ID)")
                {
                    break;
                }
            }

            outlines.Add("switch(node.Symbol.ID)");
            using (outlines.Indent())
            {
                for (start += 2; start < inlines.Count; ++start)
                {
                    var line = inlines[start];

                    if (line == "\t\t\t}")
                    {
                        outlines.Add("default:");
                        outlines.Add2("throw new NotImplementedException();");
                        break;
                    }

                    line = line.Replace("visitor.", "return (T)");
                    line = line.Replace(" break;", string.Empty);
                    line = line.TrimStart('\t');

                    outlines.Add(line);
                }
            }
        }

        private void Virtuals(IReadOnlyList<string> inlines, Indentable outlines)
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

        private void Virtual(string line, Indentable outlines)
        {
            line = line.Substring(1); // remove '\t'
            line = line.Replace(" {}", string.Empty);
            line = line.Replace("public virtual void", "protected virtual object");
            line = line.TrimStart('\t');
            outlines.Add($"{line}");

            using (outlines.Indent())
            {
                outlines.Add($"return VisitChildren(node).FirstOrDefault();");
            }
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
