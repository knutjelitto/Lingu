using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            public int First = 55;
            public readonly string Namespace = "Lipeg.Command";
            public readonly string CtxName = "context";
            public readonly string CurName = "current";

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
                CS =  new CSharper(Writer);
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
                        CS.L($"using {@using};");
                    }
                    CS.L();
                    CS.Block($"public partial class {Cfg.ParserClass} : ParserBase", () =>
                    {
                        var more = false;
                        foreach (var rule in Grammar.AllRules)
                        {
                            if (more)
                            {
                                CS.L();
                            }
                            VisitRule(rule);
                            more = true;
                        }
                    });
                });
            }

            protected override void VisitRule(IRule rule)
            {
                CS.L($"// {rule.Identifier} -> {Cfg.Capa(rule.Identifier)}");
                CS.Block($"public IResult {Cfg.Capa(rule.Identifier)}(IContext {Cfg.CtxName})", () =>
                {
                    RuleNo += 1;
                    if (RuleNo > Cfg.First)
                    {
                        CS.L("throw new NotImplementedException();");
                        return;
                    }

                    Locals.Reset();
                    using (Locals.Result())
                    {
                        CS.L($"var {Cfg.CurName} = {Cfg.CtxName};");
                        VisitExpression(rule.Expression);
                        CS.L($"return {Locals.Peek()};");
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
                //Locals.PeekPrep(Writer);
                CS.Indent(
                    "// SequenceExpression:",
                    () => 
                    {
                        using (var nodes = Locals.Use("nodes"))
                        {
                            CS.L($"{nodes} = new List<INode>({expression.Sequence.Count});");
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
                                CS.L($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                CS.L($"{Cfg.CurName} = {Locals.Peek()}.Next;");
                                AddToList(nodes, exprs, index + 1);
                            });
                    }
                    else
                    {
                        CS.L($"{Locals.Peek()} = Result.Success({nodes}[0], {Cfg.CurName}, {nodes}.ToArray());");
                    }
                }
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
#if true
                CS.L($"{Locals.Peek()} = {Cfg.Capa(expression.Identifier)}({Cfg.CurName});");
#else
                Locals.PeekPrep(Writer);
                CS.Block(
                    "// NameExpression:",
                    () =>
                    {
                        CS.L($"{Locals.Peek()} = {Cfg.Capa(expression.Identifier)}({Cfg.CurName});");
                    });
#endif
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                //Locals.PeekPrep(Writer);
                CS.Indent(
                    "// DropExpression:",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                CS.L($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next);");
                            });
                    });
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                //Locals.PeekPrep(Writer);
                CS.Indent(
                    "// LiftExpression:",
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
                                    CS.L($"{nodes} = new List<INode>();");
                                    CS.Block(
                                        $"foreach ({node} in {Locals.Peek()}.Nodes)",
                                        () => { CS.L($"{nodes}.AddRange({node}.Children);"); });

                                    CS.L($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {nodes}.ToArray());");
                                }
                            });
                    });
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                CS.L("// StringLiteralExpression:");
                var str = Locals.Use("str");
                CS.L($"{str} = \"{CharRep.InCSharp(expression.Value)}\";");
                CS.L($"{Locals.Peek()} = this.MatchString({Cfg.CurName}, {str});");
            }

            protected override void VisitStarExpression(StarExpression star)
            {
                Locals.PeekPrep(Writer);
                CS.Indent(
                    "// StarExpression:",
                    () =>
                    {
                        using (var start = Locals.Use("start"))
                        using (var nodes = Locals.Use("nodes"))
                        using (var location = Locals.Use("location"))
                        using (var node = Locals.Use("node"))
                        {
                            CS.L($"{start} = {Cfg.CurName};");
                            CS.L($"{nodes} = new List<INode>();");
                            CS.ForEver(
                                () =>
                                {
                                    VisitExpression(star.Expression);
                                    CS.If(
                                        $"{Locals.Peek()}.IsSuccess",
                                        () =>
                                        {
                                            CS.L($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                            CS.L($"{Cfg.CurName} = {Locals.Peek()}.Next;");
                                        },
                                        () =>
                                        {
                                            CS.L("break;");
                                        });
                                });

                            CS.L($"{location} = Location.From({start}, {Cfg.CurName});");
                            CS.L($"{node} = NodeList.From({location}, NodeSymbols.Star, {nodes});");
                            CS.L($"{Locals.Peek()} = Result.Success({location}, {Cfg.CurName}, {node});");
                        }
                    });
            }

            protected override void VisitPlusExpression(PlusExpression plus)
            {
                Locals.PeekPrep(Writer);
                CS.Indent(
                    "// PlusExpression:",
                    () =>
                    {
                        using(var start = Locals.Use("start"))
                        using (var nodes = Locals.Use("nodes"))
                        {
                            CS.L($"{start} = {Cfg.CurName};");
                            CS.L($"{nodes} = new List<INode>();");
                            CS.ForEver(
                                () =>
                                {
                                    VisitExpression(plus.Expression);                                    
                                    CS.If(
                                        $"{Locals.Peek()}.IsSuccess",
                                        () =>
                                        {
                                            CS.L($"{nodes}.AddRange({Locals.Peek()}.Nodes);");
                                            CS.L($"{Cfg.CurName} = {Locals.Peek()}.Next;");
                                        },
                                        () =>
                                        {
                                            CS.L("break;");
                                        });
                                });
                            CS.If(
                                $"{nodes}.Count > 0",
                                () =>
                                {
                                    using (var location = Locals.Use("location"))
                                    using (var node = Locals.Use("node"))
                                    {
                                        CS.L($"{location} = Location.From({start}, {Cfg.CurName});");
                                        CS.L($"{node} = NodeList.From({location}, NodeSymbols.Plus, {nodes}.ToArray());");
                                        CS.L($"{Locals.Peek()} = Result.Success({location}, {Cfg.CurName}, {node});");
                                    }
                                },
                                () =>
                                {
                                    CS.L($"{Locals.Peek()} = Result.Fail({start});");
                                });
                        }
                    });
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                //Locals.PeekPrep(Writer);
                CS.Indent(
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
                Locals.PeekPrep(Writer);
                CS.Block(
                    "// OptionalExpression:",
                    () =>
                    {
                        VisitExpression(optional.Expression);
                        using (var node = Locals.Use("node"))
                        {
                            CS.L($"{node} = NodeList.From({Locals.Peek()}, NodeSymbols.Optional, {Locals.Peek()}.Nodes.ToArray());");
                            CS.If(
                                $"{Locals.Peek()}.IsSuccess",
                                () =>
                                {
                                    CS.L($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {node});");
                                },
                                () =>
                                {
                                    CS.L($"{Locals.Peek()} = Result.Success({Cfg.CurName}, {Cfg.CurName}, {node});");
                                });
                        }
                    });
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Locals.PeekPrep(Writer);
                CS.Block(
                    "// InlineExpression:",
                    () =>
                    {
                        CS.L($"// {expression.Rule}");
                        CS.L($"{Locals.Peek()} = {Cfg.Capa(expression.Rule.Identifier)}({Cfg.CurName});");
                    });
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                Locals.PeekPrep(Writer);
                CS.Indent(
                    "// NotExpression:",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                CS.L($"{Locals.Peek()} = Result.Fail({Cfg.CurName});");
                            },
                            () =>
                            {
                                CS.L($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Cfg.CurName});");
                            });
                    });
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                Locals.PeekPrep(Writer);
                CS.Indent(
                    "// AndExpression:",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Peek()}.IsSuccess",
                            () =>
                            {
                                CS.L($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Cfg.CurName});");
                            },
                            () =>
                            {
                                CS.L($"{Locals.Peek()} = Result.Fail({Cfg.CurName});");
                            });
                    });
            }

            protected override void VisitAnyExpression(AnyExpression expression)
            {
                Locals.PeekPrep(Writer);
                CS.Block(
                    "// VisitAnyExpression:",
                    () =>
                    {
                        CS.If(
                            $"!{Cfg.CurName}.AtEnd",
                            () =>
                            {
                                using (var next = Locals.Use("next"))
                                using (var location = Locals.Use("location"))
                                using (var node = Locals.Use("node"))
                                {
                                    CS.L($"{next} = {Cfg.CurName}.Advance(1);");
                                    CS.L($"{location} = Location.From({Cfg.CurName}, {next});");
                                    CS.L($"{node} = Leaf.From({location}, NodeSymbols.Any, ((char){Cfg.CurName}.Current).ToString(CultureInfo.InvariantCulture));");
                                    CS.L($"{Locals.Peek()} = Result.Success({node}, {next}, {node});");
                                }
                            },
                            () =>
                            {
                                CS.L($"{Locals.Peek()} = Result.Fail({Cfg.CurName});");
                            });
                    });
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                Locals.PeekPrep(Writer);
                CS.Block(
                    "// FuseExpression:",
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
                                    CS.L($"{value} = string.Join(string.Empty, {Locals.Peek()}.Nodes.Select(n => n.Fuse()));");
                                    CS.L($"{node} = Leaf.From({Locals.Peek()}, NodeSymbols.Fusion, {value});");
                                    CS.L($"{Locals.Peek()} = Result.Success({Locals.Peek()}, {Locals.Peek()}.Next, {node});");
                                }
                            });
                    });
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                var characters = new SortedSet<int>();
                foreach (var part in expression.Choices)
                {
                    characters.UnionWith(part.Values);
                }
                var array = String.Join(",", characters);

#if true
                CS.L("// ClassExpression");
                using (var values = Locals.Use("values"))
                {

                    CS.L($"{values} = new []{{{array}}};");

                    var cond = expression.Negated
                                   ? "< 0"
                                   : ">= 0";
                    var check = characters.Count > 8
                                    ? $"(cur) => Array.BinarySearch({values}, cur) {cond}"
                                    : $"(cur) => Array.IndexOf({values}, cur) {cond}";

                    CS.L($"{Locals.Peek()} = this.MatchPredicate({Cfg.CurName}, {check});");
                }
#else
#endif
            }

            protected void Space(Expression expression)
            {
                if (expression.Attr.IsWithSpacing)
                {
                    CS.L($"// SHOULD SPACE <{Cfg.Capa(Grammar.Attr.Spacing.Identifier)}>");
                    CS.L($"{Cfg.CurName} = {Cfg.Capa(Grammar.Attr.Spacing.Identifier)}({Cfg.CurName}).Next;");
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
