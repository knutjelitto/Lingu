using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

using Lipeg.Runtime.Tools;
using Lipeg.SDK.Common;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Builders
{
    public class BuildCSharp : IBuildPass
    {
        private class Config
        {
            public readonly bool Disable = false;
            public readonly string Namespace = "Lipeg.Command";
            public readonly string CtxName = "context";
            public readonly string CurName = "current";
            public readonly string MatchString = "this.__MatchString";
            public readonly string MatchPredicate = "this.__MatchPredicate";

            private const string ParserClassNameSuffix = "Parser";


            public Config(Grammar grammar)
            {
                Grammar = grammar;
            }

            public Grammar Grammar { get; }

            public string ParserClass => $"{Capa(Grammar.Name)}{ParserClassNameSuffix}";

            [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Scheiß drauf")]
            public IEnumerable<string> Usings => new[] { "System", "System.Collections.Generic", "System.Globalization", "System.Linq", "Lipeg.SDK.Tree", "Lipeg.Runtime" };

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

            if (Cfg.Disable) writer.WriteLine();

            new Visitor(writer, Cfg, Grammar).Visit();

            if (Cfg.Disable) writer.WriteLine();

            writer.Persist(OutFile);
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(CsWriter writer, Config cfg, Grammar grammar)
                : base(grammar)
            {
                Writer = writer;
                CS =  new CSharper(Writer, true);
                Cfg = cfg;
            }

            public CsWriter Writer { get; }
            public CSharper CS { get; }
            public Config Cfg { get; }
            public int RuleNo { get; set; } = 0;

            public void Visit()
            {
                CS.Block($"namespace {Cfg.Namespace}", () =>
                {
                    foreach (var @using in Cfg.Usings)
                    {
                        CS.Line($"using {@using};");
                    }
                    CS.Line();
                    CS.Block($"public partial class {Cfg.ParserClass} : ParserBase", () =>
                    {
                        var more = false;
                        foreach (var rule in Grammar.AllRules)
                        {
                            if (more)
                            {
                                CS.Line();
                            }
                            VisitRule(rule);
                            more = true;
                        }
                    });
                });
            }

            protected override void VisitRule(IRule rule)
            {
                CS.Line($"// {rule.Identifier} -> {Cfg.Capa(rule.Identifier)}");
                CS.Block($"public IResult {Cfg.Capa(rule.Identifier)}(IContext {Cfg.CtxName})", () =>
                {
                    RuleNo += 1;

                    Locals.Reset();
                    using (Locals.Result())
                    {
                        CS.Line($"var {Cfg.CurName} = {Cfg.CtxName};");
                        VisitExpression(rule.Expression);
                        CS.Line($"return {Locals.Peek()};");
                    }
                });
            }

            public override void VisitExpression(Expression expression)
            {
                Space(expression);
                base.VisitExpression(expression);
            }

            // <**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**>

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                CS.IndentInOut(
                    "SequenceExpression",
                    () => 
                    {
                        using (var nodes = Locals.Use("nodes"))
                        {
                            CS.Line($"{nodes} = new List<INode>();");
                            AddToList(nodes, expression.Sequence.ToList(), 0);
                        }
                    });

                void AddToList(Local nodes, IReadOnlyList<Expression> exprs, int index)
                {
                    if (index < exprs.Count)
                    {
                        VisitExpression(exprs[index]);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                CS.Line($"{Cfg.CurName} = {Locals.Peek()}.Next;");
                                CS.Line($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                AddToList(nodes, exprs, index + 1);
                            });
                    }
                    else
                    {
                        CS.Line($"{Locals.Peek()} = Result.Success({nodes}[0], {Cfg.CurName}, {nodes}.ToArray());");
                    }
                }
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                CS.IndentInOut(
                    "NameExpression",
                    () =>
                    {
                        CS.Line($"{Locals.Peek()} = {Cfg.Capa(expression.Identifier)}({Cfg.CurName});");
                    });
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                CS.IndentInOut(
                    "DropExpression",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                CS.Line($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next);");
                            });
                    });
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                CS.IndentInOut(
                    "LiftExpression",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                using (var nodes = Locals.Use("nodes"))
                                using (var node = Locals.Use("node"))
                                {
                                    CS.Line($"{nodes} = new List<INode>();");
                                    CS.Block(
                                        $"foreach ({node} in {Locals.Peek()}.Nodes)",
                                        () =>
                                        {
                                            CS.Line($"{nodes}.AddRange({node}.Children);");
                                        });

                                    CS.Line($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {nodes}.ToArray());");
                                }
                            });
                    });
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                CS.IndentInOut(
                    "StringLiteralExpression",
                    () =>
                    {
                        using (var str = Locals.Use("str"))
                        {
                            CS.Line($"{str} = \"{CharRep.InCSharp(expression.Value)}\";");
                            CS.Line($"{Locals.Peek()} = {Cfg.MatchString}({Cfg.CurName}, {str});");
                        }
                    });
            }

            protected override void VisitStarExpression(StarExpression star)
            {
                CS.IndentInOut(
                    "StarExpression",
                    () =>
                    {
                        using (var start = Locals.Use("start"))
                        using (var nodes = Locals.Use("nodes"))
                        using (var location = Locals.Use("location"))
                        using (var node = Locals.Use("node"))
                        {
                            CS.Line($"{start} = {Cfg.CurName};");
                            CS.Line($"{nodes} = new List<INode>();");
                            Locals.PeekPrep(Writer);
                            CS.ForEver(
                                () =>
                                {
                                    VisitExpression(star.Expression);
                                    CS.If(
                                        $"{Locals.Peek()}.IsSuccess",
                                        () =>
                                        {
                                            CS.Line($"{Cfg.CurName} = {Locals.Peek()}.Next;");
                                            CS.Line($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                        },
                                        () =>
                                        {
                                            CS.Line("break;");
                                        });
                                });

                            CS.Line($"{location} = Location.From({start}, {Cfg.CurName});");
                            CS.Line($"{node} = NodeList.From({location}, NodeSymbols.Star, {nodes});");
                            CS.Line($"{Locals.Peek()} = Result.Success({location}, {Cfg.CurName}, {node});");
                        }
                    });
            }

            protected override void VisitPlusExpression(PlusExpression plus)
            {
                CS.IndentInOut(
                    "PlusExpression",
                    () =>
                    {
                        using(var start = Locals.Use("start"))
                        using (var nodes = Locals.Use("nodes"))
                        {
                            CS.Line($"{start} = {Cfg.CurName};");
                            CS.Line($"{nodes} = new List<INode>();");
                            Locals.PeekPrep(Writer);
                            CS.ForEver(
                                () =>
                                {
                                    VisitExpression(plus.Expression);                                    
                                    CS.If(
                                        $"{Locals.Peek()}.IsSuccess",
                                        () =>
                                        {
                                            CS.Line($"{Cfg.CurName} = {Locals.Peek()}.Next;");
                                            CS.Line($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                        },
                                        () =>
                                        {
                                            CS.Line("break;");
                                        });
                                });
                            CS.If(
                                $"{nodes}.Count > 0",
                                () =>
                                {
                                    using (var location = Locals.Use("location"))
                                    using (var node = Locals.Use("node"))
                                    {
                                        CS.Line($"{location} = Location.From({start}, {Cfg.CurName});");
                                        CS.Line($"{node} = NodeList.From({location}, NodeSymbols.Plus, {nodes}.ToArray());");
                                        CS.Line($"{Locals.Peek()} = Result.Success({location}, {Cfg.CurName}, {node});");
                                    }
                                },
                                () =>
                                {
                                    CS.Line($"{Locals.Peek()} = Result.Fail({start});");
                                });
                        }
                    });
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                CS.IndentInOut(
                    "ChoiceExpression",
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
                            CS.If(
                                $"!{Locals.Peek()}.IsSuccess",
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
                CS.IndentInOut(
                    "OptionalExpression",
                    () =>
                    {
                        VisitExpression(optional.Expression);
                        using (var node = Locals.Use("node"))
                        {
                            CS.Line($"{node} = NodeList.From({Locals.Peek()}, NodeSymbols.Optional, {Locals.Peek()}.Nodes.ToArray());");
                            CS.If(
                                $"{Locals.Peek()}.IsSuccess",
                                () =>
                                {
                                    CS.Line($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {node});");
                                },
                                () =>
                                {
                                    CS.Line($"{Locals.Peek()} = Result.Success({Cfg.CurName}, {Cfg.CurName}, {node});");
                                });
                        }
                    });
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                CS.IndentInOut(
                    "InlineExpression",
                    () =>
                    {
                        CS.Line($"{Locals.Peek()} = {Cfg.Capa(expression.Rule.Identifier)}({Cfg.CurName});");
                    });
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                CS.IndentInOut(
                    "NotExpression",
                    () =>
                    {
                        Locals.PeekPrep(Writer);
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                CS.Line($"{Locals.Peek()} = Result.Fail({Cfg.CurName});");
                            },
                            () =>
                            {
                                CS.Line($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Cfg.CurName});");
                            });
                    });
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                CS.IndentInOut(
                    "AndExpression",
                    () =>
                    {
                        Locals.PeekPrep(Writer);
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                CS.Line($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Cfg.CurName});");
                            },
                            () =>
                            {
                                CS.Line($"{Locals.Peek()} = Result.Fail({Cfg.CurName});");
                            });
                    });
            }

            protected override void VisitAnyExpression(AnyExpression expression)
            {
                CS.IndentInOut(
                    "AnyExpression",
                    () =>
                    {
                        Locals.PeekPrep(Writer);
                        CS.If(
                            $"!{Cfg.CurName}.AtEnd",
                            () =>
                            {
                                using (var next = Locals.Use("next"))
                                using (var location = Locals.Use("location"))
                                using (var node = Locals.Use("node"))
                                {
                                    CS.Line($"{next} = {Cfg.CurName}.Advance(1);");
                                    CS.Line($"{location} = Location.From({Cfg.CurName}, {next});");
                                    CS.Line($"{node} = Leaf.From({location}, NodeSymbols.Any, ((char){Cfg.CurName}.Current).ToString(CultureInfo.InvariantCulture));");
                                    CS.Line($"{Locals.Peek()} = Result.Success({node}, {next}, {node});");
                                }
                            },
                            () =>
                            {
                                CS.Line($"{Locals.Peek()} = Result.Fail({Cfg.CurName});");
                            });
                    });
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                CS.IndentInOut(
                    "FuseExpression",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                using (var value = Locals.Use("value"))
                                using (var node = Locals.Use("node"))
                                {
                                    CS.Line($"{value} = string.Join(string.Empty, {Locals.Peek()}.Nodes.Select(n => n.Fuse()));");
                                    CS.Line($"{node} = Leaf.From({Locals.Peek()}, NodeSymbols.Fusion, {value});");
                                    CS.Line($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {node});");
                                }
                            });
                    });
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                CS.IndentInOut(
                    "ClassExpression",
                    () =>
                    {
                        var characters = new SortedSet<int>();
                        foreach (var part in expression.Choices)
                        {
                            characters.UnionWith(part.Values);
                        }
                        var array = String.Join(",", characters);

                        using (var values = Locals.Use("values"))
                        {

                            CS.Line($"{values} = new []{{{array}}};");

                            var cond = expression.Negated
                                           ? "< 0"
                                           : ">= 0";
                            var check = characters.Count > 8
                                            ? $"_current => Array.BinarySearch({values}, _current) {cond}"
                                            : $"_current => Array.IndexOf({values}, _current) {cond}";

                            CS.Line($"{Locals.Peek()} = {Cfg.MatchPredicate}({Cfg.CurName}, {check});");
                        }
                    });
            }

            protected void Space(Expression expression)
            {
                if (expression.Attr.IsWithSpacing)
                {
                    CS.IndentInOut(
                        "SPACE",
                        () =>
                        {
                            CS.Line($"/*SKIP SPACE*/ {Cfg.CurName} = {Cfg.Capa(Grammar.Attr.Spacing.Identifier)}({Cfg.CurName}).Next;");
                        });
                }
            }

            // <**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**>
            // **><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><
            // *><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><*
            // ><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**
            // <**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**><**>

            // >===>

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                // handled higher
                throw new NotImplementedException();
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                // handled higher
                throw new NotImplementedException();
            }


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
