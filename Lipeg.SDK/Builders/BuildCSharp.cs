using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Common;
using Lipeg.SDK.Output;
using Lipeg.SDK.Parsers;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Builders
{
    public class BuildCSharp : IBuildPass
    {
        private class Config
        {
            public readonly bool Disable = false;
            public int First = 30;
            public readonly string Namespace = "Lipeg.Generated";
            private const string ParserClassNameSuffix = "Parser";

            public Config(Grammar grammar)
            {
                Grammar = grammar;
            }

            public Grammar Grammar { get; }

            public string ParserClass => $"{Capa(Grammar.Name)}{ParserClassNameSuffix}";

            [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Scheiß drauf")]
            public IEnumerable<string> Usings => new[] { "System", "System.Collections.Generic", "System.Globalization", "System.Linq", "Lipeg.SDK.Parsers", "Lipeg.SDK.Tree", "Lipeg.Runtime" };

            public string Capa(Identifier id)
            {
                Debug.Assert(Grammar != null);

                var parts = id.Name.Split('-', '.');
                var builder = new StringBuilder();
                foreach (var part in parts)
                {
                    builder.Append(char.ToUpperInvariant(part[0]) + part.Substring(1));
                }

                return builder.ToString();
            }
        }

        public BuildCSharp(Grammar grammar, FileRef outFile)
        {
            Grammar = grammar;
            OutFile = outFile;
            Cfg = new Config(Grammar);
        }

        public Grammar Grammar { get; }
        public FileRef OutFile { get; }
        private Config Cfg { get; }

        public void Build()
        {
            var writer = new CsWriter();

            if (Cfg.Disable) writer.WriteLine("#if false");

            new Visitor(writer, Cfg, Grammar).Visit();

            if (Cfg.Disable) writer.WriteLine("#endif");

            writer.Persist(OutFile);
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(CsWriter writer, Config cfg, Grammar grammar)
                : base(grammar)
            {
                Writer = writer;
                Cfg = cfg;
            }

            public CsWriter Writer { get; }
            public Config Cfg { get; }
            public int RuleNo { get; set; } = 0;

            public void Visit()
            {
                Writer.Block($"namespace {Cfg.Namespace}", () =>
                {
                    foreach (var @using in Cfg.Usings)
                    {
                        Writer.WriteLine($"using {@using};");
                    }
                    Writer.WriteLine();
                    Writer.Block($"public partial class {Cfg.ParserClass}", () =>
                    {
                        var more = false;
                        foreach (var rule in Grammar.AllRules)
                        {
                            if (more)
                            {
                                Writer.WriteLine();
                            }
                            VisitRule(rule);
                            more = true;
                        }
                    });
                });
            }

            protected override void VisitRule(IRule rule)
            {
                Writer.WriteLine($"// {rule.Identifier} -> {Cfg.Capa(rule.Identifier)}");
                Writer.Block($"public IResult {Cfg.Capa(rule.Identifier)}(IContext context)", () =>
                {
                    RuleNo += 1;
                    if (RuleNo > Cfg.First)
                    {
                        Writer.WriteLine("throw new NotImplementedException();");
                        return;
                    }

                    Locals.Reset();
                    using (Locals.Result())
                    {
                        Writer.WriteLine("var current = context;");
                        VisitExpression(rule.Expression);
                        Writer.WriteLine($"return {Locals.Peek()};");
                    }
                });
            }

            public override void VisitExpression(Expression expression)
            {
                base.VisitExpression(expression);
            }

            // <**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**>

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// SequenceExpression:",
                    () => 
                    {
                        using (var nodes = Locals.Use("nodes"))
                        {
                            Writer.WriteLine($"{nodes} = new List<INode>({expression.Sequence.Count});");
                            //using (Locals.Result())
                            //{
                            AddToList(nodes, expression.Sequence.ToList(), 0);
                            //}
                        }

                    });

                void AddToList(Local nodes, IReadOnlyList<Expression> exprs, int index)
                {
                    if (index < exprs.Count)
                    {
                        VisitExpression(exprs[index]);
                        Writer.Block(
                            $"if ({Locals.Peek()}.IsSuccess)",
                            () =>
                            {
                                Writer.WriteLine($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                Writer.WriteLine($"current = {Locals.Peek()}.Next;");
                                AddToList(nodes, exprs, index + 1);
                            });
                    }
                    else
                    {
                        Writer.WriteLine($"{Locals.Peek()} = Result.Success({nodes}[0], current, {nodes}.ToArray());");
                    }
                }
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// NameExpression:",
                    () =>
                    {
                        Writer.WriteLine($"{Locals.Peek()} = {Cfg.Capa(expression.Identifier)}(current);");
                    });
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// DropExpression:",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        Writer.Block(
                            $"if ({Locals.Peek()}.IsSuccess)",
                            () =>
                            {
                                Writer.WriteLine($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next);");
                            });
                    });
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// LiftExpression:",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        Writer.Block(
                            $"if ({Locals.Peek()}.IsSuccess)",
                            () =>
                            {
                                using (var nodes = Locals.Use("nodes"))
                                using (var node = Locals.Use("node"))
                                {
                                    Writer.WriteLine($"{nodes} = new List<INode>();");
                                    Writer.Block(
                                        $"foreach ({node} in {Locals.Peek()}.Nodes)",
                                        () => { Writer.WriteLine($"{nodes}.AddRange({node}.Children);"); });

                                    Writer.WriteLine($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {nodes}.ToArray());");
                                }
                            });
                    });
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// StringLiteralExpression:",
                    () =>
                    {
                        var str = Locals.Use("str");
                        Writer.WriteLine($"{str} = \"{CharRep.InText(expression.Value)}\";");

                        Locals.PeekPrep(Writer);
                        Writer.Block(
                            $"if (current.StartsWith({str}))",
                            () =>
                            {
                                using (var next = Locals.Use("next"))
                                using (var location = Locals.Use("location"))
                                using (var node = Locals.Use("node"))
                                {
                                    Writer.WriteLine($"{next} = current.Advance({str}.Length);");
                                    Writer.WriteLine($"{location} = Location.From(current, {next});");
                                    Writer.WriteLine($"{node} = Leaf.From({location}, NodeSymbols.StringLiteral, {str});");
                                    Writer.WriteLine($"{Locals.Peek()} = Result.Success({location}, {next}, {node});");
                                    Writer.WriteLine($"current = {next};");
                                }
                            });
                        Writer.Block(
                            $"else",
                            () =>
                            {
                                Writer.WriteLine($"{Locals.Peek()} = Result.Fail(current);");
                            });
                    });
            }

            protected override void VisitStarExpression(StarExpression star)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// StarExpression:",
                    () =>
                    {
                        using (var start = Locals.Use("start"))
                        using (var nodes = Locals.Use("nodes"))
                        using (var location = Locals.Use("location"))
                        using (var node = Locals.Use("node"))
                        {
                            Writer.WriteLine($"{start} = current;");
                            Writer.WriteLine($"{nodes} = new List<INode>();");
                            Writer.Block(
                                "for (;;)",
                                () =>
                                {
                                    VisitExpression(star.Expression);
                                    Writer.Block(
                                        $"if ({Locals.Peek()}.IsSuccess)",
                                        () =>
                                        {
                                            Writer.WriteLine($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                            Writer.WriteLine($"current = {Locals.Peek()}.Next;");
                                        });
                                    Writer.Block(
                                        $"else",
                                        () =>
                                        {
                                            Writer.WriteLine("break;");
                                        });
                                });

                            Writer.WriteLine($"{location} = Location.From(start, current);");
                            Writer.WriteLine($"{node} = NodeList.From({location}, NodeSymbols.Star, {nodes});");
                            Writer.WriteLine($"{Locals.Peek()} = Result.Success({location}, current, {node});");
                        }
                    });
            }

            protected override void VisitPlusExpression(PlusExpression plus)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// PlusExpression:",
                    () =>
                    {
                        using(var start = Locals.Use("start"))
                        using (var nodes = Locals.Use("nodes"))
                        {
                            Writer.WriteLine($"{start} = current;");
                            Writer.WriteLine($"{nodes} = new List<INode>();");
                            Writer.Block(
                                "for (;;)",
                                () =>
                                {
                                    VisitExpression(plus.Expression);                                    
                                    Writer.Block(
                                        $"if ({Locals.Peek()}.IsSuccess)",
                                        () =>
                                        {
                                            Writer.WriteLine($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                            Writer.WriteLine($"current = {Locals.Peek()}.Next;");
                                        });
                                    Writer.Block(
                                        $"else",
                                        () =>
                                        {
                                            Writer.WriteLine("break;");
                                        });
                                });
                            Writer.Block(
                                $"if ({nodes}.Count > 0)",
                                () =>
                                {
                                    using (var location = Locals.Use("location"))
                                    using (var node = Locals.Use("node"))
                                    {
                                        Writer.WriteLine($"{location} = Location.From({start}, current);");
                                        Writer.WriteLine($"{node} = NodeList.From({location}, NodeSymbols.Plus, {nodes}.ToArray());");
                                        Writer.WriteLine($"{Locals.Peek()} = Result.Success({location}, current, {node});");
                                    }
                                });
                            Writer.Block(
                                $"else",
                                () =>
                                {
                                    Writer.WriteLine($"{Locals.Peek()} = Result.Fail({start});");
                                });
                        }
                    });
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// ChoiceExpression:",
                    () =>
                    {
                        AddToList(expression.Choices.ToList(), 0);
                    });
                
                void AddToList(IReadOnlyList<Expression> exprs, int index)
                {
                    if (index < exprs.Count)
                    {
                        VisitExpression(exprs[index]);
                        index += 1;
                        if (index < exprs.Count)
                        {
                            Writer.Block(
                                $"if (!{Locals.Peek()}.IsSuccess)",
                                () =>
                                {
                                    AddToList(exprs, index);
                                });
                        }
                    }
                }
            }

            protected override void VisitOptionalExpression(OptionalExpression optional)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// OptionalExpression:",
                    () =>
                    {
                        VisitExpression(optional.Expression);
                        using (var node = Locals.Use("node"))
                        {
                            Writer.WriteLine($"{node} = NodeList.From({Locals.Peek()}, NodeSymbols.Optional, {Locals.Peek()}.Nodes.ToArray());");
                            Writer.Block(
                                $"if ({Locals.Peek()}.IsSuccess)",
                                () =>
                                {
                                    Writer.WriteLine($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {node});");
                                });
                            Writer.Block(
                                $"else",
                                () =>
                                {
                                    Writer.WriteLine($"{Locals.Peek()} = Result.Success(current, current, {node});");
                                });
                        }
                    });
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// InlineExpression:",
                    () =>
                    {
                        Writer.WriteLine($"// {expression.Rule}");
                        Writer.WriteLine($"{Locals.Peek()} = {Cfg.Capa(expression.Rule.Identifier)}(current);");
                    });
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// NotExpression:",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        Writer.Block(
                            $"if ({Locals.Peek()}.IsSuccess)",
                            () =>
                            {
                                Writer.WriteLine($"{Locals.Peek()} = Result.Success({Locals.Peek()}, current);");
                            });
                        Writer.Block(
                            $"else",
                            () =>
                            {
                                Writer.WriteLine($"{Locals.Peek()} = Result.Fail(current);");
                            });
                    });
            }

            protected override void VisitAnyExpression(AnyExpression expression)
            {
                Locals.PeekPrep(Writer);
                Writer.Block(
                    "// VisitAnyExpression:",
                    () =>
                    {
                        Writer.Block(
                            $"if (!current.AtEnd)",
                            () =>
                            {
                                using (var next = Locals.Use("next"))
                                using (var location = Locals.Use("location"))
                                using (var node = Locals.Use("node"))
                                {
                                    Writer.WriteLine($"{next} = current.Advance(1);");
                                    Writer.WriteLine($"{location} = Location.From(current, {next});");
                                    Writer.WriteLine($"{node} = Leaf.From({location}, NodeSymbols.Any, ((char)current.Current).ToString(CultureInfo.InvariantCulture));");
                                    Writer.WriteLine($"{Locals.Peek()} = Result.Success({node}, {next}, {node});");
                                }
                            });
                        Writer.Block(
                            $"else",
                            () =>
                            {
                                Writer.WriteLine($"{Locals.Peek()} = Result.Fail(current);");
                            });
                    });
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                Writer.WriteLine("VisitFuseExpression");
            }

            // <**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**>
            // **><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><
            // *><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><*
            // ><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**
            // <**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**>

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                Writer.WriteLine("VisitClassCharExpression");
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                Writer.WriteLine("VisitClassExpression");
            }

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                Writer.WriteLine("VisitClassRangeExpression");
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                Writer.WriteLine("VisitAndExpression");
            }

            // >===>

            public override void VisitGrammar()
            {
                base.VisitGrammar();
            }

            protected override void VisitGrammarLexicalRules()
            {
                base.VisitGrammarLexicalRules();
            }

            public override void VisitGrammarOptions()
            {
                base.VisitGrammarOptions();
            }

            protected override void VisitGrammarSyntaxRules()
            {
                base.VisitGrammarSyntaxRules();
            }

            protected override void VisitOption(Option option)
            {
                base.VisitOption(option);
            }

            public override void VisitGrammarRules()
            {
                base.VisitGrammarRules();
            }
        }

        private class Local : IDisposable
        {
            private readonly Cache cache;
            private readonly int id;
            private int useCount;

            public Local(Cache cache, int id)
            {
                Debug.Assert(id >= 1);
                this.cache = cache;
                this.id = id;
                this.useCount = 0;
            }

            public string Name
            {
                get
                {
                    if (this.id == 1)
                    {
                        return this.cache.Stem;
                    }
                    return this.cache.Stem + this.id;
                }
            }

            public void PrepResult(IWriter writer)
            {
                if (this.cache.Stem == "result")
                {
                    if (this.useCount == 0)
                    {
                        writer.WriteLine($"IResult {Name};");
                        this.useCount++;
                    }
                }
            }

            public void Dispose()
            {
                this.cache.Free(this);
            }

            public override string ToString()
            {
                this.useCount += 1;
                if (this.useCount == 1)
                {
                    return "var " + Name;
                }

                return Name;
            }
        }

        private static class Locals
        {
            private static Dictionary<string, Cache> cached = new Dictionary<string, Cache>();
            private static Stack<Local> results = new Stack<Local>();

            public static void Reset()
            {
                cached.Clear();
                results.Clear();
            }

            public static IDisposable Result()
            {
                var result = Use("result");
                results.Push(result);
                return new Disposable(() =>
                {
                    Debug.Assert(results.Peek() == result);
                    result.Dispose();
                    results.Pop();
                });
            }

            public static Local Peek()
            {
                return results.Peek();
            }

            public static void PeekPrep(IWriter writer)
            {
                results.Peek().PrepResult(writer);
            }

            public static Local Use(string stem)
            {
                if (!cached.TryGetValue(stem, out var cache))
                {
                    cache = new Cache(stem);
                    cached.Add(stem, cache);
                }

                return cache.Use();
            }
        }

        private class Cache
        {
            public Cache(string stem)
            {
                Stem = stem;
                this.next = 1;
            }

            public Local Use()
            {
                Local use;
                if (this.free.Count > 0)
                {
                    use = this.free[0];
                    this.free.RemoveAt(0);
                }
                else
                {
                    use = new Local(this, this.next);
                    this.next += 1;
                }

                this.used.Add(use);
                return use;
            }

            public void Free(Local local)
            {
                Debug.Assert(this.used.Contains(local));
                this.used.Remove(local);
                //this.free.Add(local);
            }

            public string Stem { get; }
            private int next;
            private List<Local> used = new List<Local>();
            private List<Local> free = new List<Local>();
        }
    }
}
