using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Common;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using Microsoft.CodeAnalysis;

namespace Lipeg.SDK.Builders
{
    public class BuildCSharp : IBuildPass
    {
        private class Config
        {
            public readonly bool Disable = false;
            public readonly string Namespace = "Lipeg.Command";
            public readonly string ParserClassNameSuffix = "Parser";
            public readonly string CtxName = "context";
            public readonly string CurName = "current";

            public readonly string IContext = nameof(Runtime.IContext);
            public readonly string IResult = nameof(Runtime.IResult);

            public readonly string ParserBase = nameof(ParserBase);

            public readonly string MatchString = nameof(IParserTools.__MatchString);
            public readonly string MatchPredicate = nameof(IParserTools.__MatchPredicate);
            public readonly string FinishRule = nameof(IParserTools.__FinishRule);

            public readonly string SkipSpace = nameof(IParserTools.__SkipSpace);
            public readonly string ParseWithCache = nameof(IParserTools.__Parse);
            public readonly string ClearCache = nameof(IParserTools.__ClearCache);

            public readonly string InterfaceParse = nameof(IParser.Parse);


            public Config(Grammar grammar)
            {
                Grammar = grammar;
            }

            public Grammar Grammar { get; }

            public string ParserClass => $"{Capa(Grammar.Name)}{ParserClassNameSuffix}";

            [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Scheiß drauf")]
            public IEnumerable<string> Usings => new[] { "System", "System.Collections.Generic", "System.Globalization", "System.Linq", "Lipeg.Runtime" };

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

            public void Visit()
            {
                CS.Block($"namespace {Cfg.Namespace}", () =>
                {
                    foreach (var @using in Cfg.Usings)
                    {
                        CS.Line($"using {@using};");
                    }
                    CS.Line();
                    CS.Block($"public partial class {Cfg.ParserClass} : {Cfg.ParserBase}", () =>
                    {
                        ImplementInterfaceParse();
                        CS.Line();
                        ImplementSkipSpace();

                        foreach (var rule in Grammar.AllRules)
                        {
                            CS.Line();
                            VisitRule(rule);
                        }
                    });
                });
            }

            private void ImplementInterfaceParse()
            {
                CS.Block($"public override {Cfg.IResult} {Cfg.InterfaceParse}({Cfg.IContext} {Cfg.CtxName})", () =>
                {
                    CS.Line($"{Cfg.ClearCache}();");
                    CS.Line($"return {Cfg.Capa(Grammar.Attr.Start.Identifier)}({Cfg.CtxName});");
                });
            }

            private void ImplementSkipSpace()
            {
                CS.Block($"public override {Cfg.IContext} {Cfg.SkipSpace}({Cfg.IContext} {Cfg.CtxName})", () =>
                {
                    CS.Line($"return {Cfg.Capa(Grammar.Attr.Spacing.Identifier)}({Cfg.CtxName}).Next;");
                });
            }

            protected override void VisitRule(IRule rule)
            {
                CS.Line($"// {rule.Identifier} -> {Cfg.Capa(rule.Identifier)}");
                CS.Block($"protected virtual {Cfg.IResult} {Cfg.Capa(rule.Identifier)}({Cfg.IContext} {Cfg.CtxName})", () =>
                {
                    Locals.Reset();
                    using (Locals.PrepareResult())
                    {
                        CS.Line($"var {Cfg.CurName} = {Cfg.CtxName};");
                        VisitExpression(rule.Expression);
                        CS.Line($"return {Cfg.FinishRule}({Locals.Result}, \"{CharRep.InCSharp(rule.Identifier.Name)}\");");
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
                            CS.Line($"{nodes} = new List<INode>(10);");
                            CheckSequence(nodes, expression.Sequence.ToList(), 0);
                        }
                    });

                void CheckSequence(Local nodes, IReadOnlyList<Expression> exprs, int index)
                {
                    if (index < exprs.Count)
                    {
                        VisitExpression(exprs[index]);
                        CS.If(
                            $"{Locals.Result}.IsSuccess",
                            () =>
                            {
                                CS.Line($"{Cfg.CurName} = {Locals.Result}.Next;");
                                CS.Line($"{nodes}.AddRange({Locals.Result}.Nodes);");
                                CheckSequence(nodes, exprs, index + 1);
                            });
                    }
                    else
                    {
                        CS.Line($"{Locals.Result} = Result.Success({nodes}[0], {Cfg.CurName}, {nodes}.ToArray());");
                    }
                }
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                CS.Line($"{Locals.Result} = {Cfg.ParseWithCache}({Cfg.Capa(expression.Identifier)}, {Cfg.CurName});");
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                CS.IndentInOut(
                    "DropExpression",
                    () =>
                    {
                        VisitExpression(expression.Expression);
                        CS.If(
                            $"{Locals.Result}.IsSuccess",
                            () =>
                            {
                                CS.Line($"{Locals.Result} = Result.Success({Locals.Result}, {Locals.Result}.Next);");
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
                            $"{Locals.Result}.IsSuccess",
                            () =>
                            {
                                using (var nodes = Locals.Use("nodes"))
                                using (var node = Locals.Use("node"))
                                {
                                    CS.Line($"{nodes} = new List<INode>(10);");
                                    CS.ForEach(
                                        $"{node} in {Locals.Result}.Nodes",
                                        () =>
                                        {
                                            CS.Line($"{nodes}.AddRange({node}.Children);");
                                        });

                                    CS.Line($"{Locals.Result} = Result.Success({Locals.Result}, {Locals.Result}.Next, {nodes}.ToArray());");
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
                        CS.Line($"{Locals.Result} = {Cfg.MatchString}({Cfg.CurName}, \"{CharRep.InCSharp(expression.Value)}\");");
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
                            CS.Line($"{nodes} = new List<INode>(10);");
                            Locals.PeekPrep(Writer);
                            CS.ForEver(
                                () =>
                                {
                                    VisitExpression(star.Expression);
                                    CS.If(
                                        $"{Locals.Result}.IsSuccess",
                                        () =>
                                        {
                                            CS.Line($"{Cfg.CurName} = {Locals.Result}.Next;");
                                            CS.Line($"{nodes}.AddRange({Locals.Result}.Nodes);");
                                        },
                                        () =>
                                        {
                                            CS.Line("break;");
                                        });
                                });

                            CS.Line($"{location} = Location.From({start}, {Cfg.CurName});");
                            CS.Line($"{node} = NodeList.From({location}, NodeSymbols.Star, {nodes});");
                            CS.Line($"{Locals.Result} = Result.Success({location}, {Cfg.CurName}, {node});");
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
                            CS.Line($"{nodes} = new List<INode>(10);");
                            Locals.PeekPrep(Writer);
                            CS.ForEver(
                                () =>
                                {
                                    VisitExpression(plus.Expression);                                    
                                    CS.If(
                                        $"{Locals.Result}.IsSuccess",
                                        () =>
                                        {
                                            CS.Line($"{Cfg.CurName} = {Locals.Result}.Next;");
                                            CS.Line($"{nodes}.AddRange({Locals.Result}.Nodes);");
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
                                        CS.Line($"{Locals.Result} = Result.Success({location}, {Cfg.CurName}, {node});");
                                    }
                                },
                                () =>
                                {
                                    CS.Line($"{Locals.Result} = Result.Fail({start});");
                                });
                        }
                    });
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                CS.IndentInOut(
                    "ChoiceExpression",
                    () => CheckChoices(expression.Choices.ToList(), 0));
                
                void CheckChoices(IReadOnlyList<Expression> exprs, int index)
                {
                    if (index < exprs.Count)
                    {
                        VisitExpression(exprs[index]);
                        index += 1;
                        if (index < exprs.Count)
                        {
                            CS.If(
                                $"!{Locals.Result}.IsSuccess",
                                () => CheckChoices(exprs, index));
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
                            CS.Line($"{node} = NodeList.From({Locals.Result}, NodeSymbols.Optional, {Locals.Result}.Nodes.ToArray());");
                            CS.If(
                                $"{Locals.Result}.IsSuccess",
                                () => CS.Line($"{Locals.Result} = Result.Success({Locals.Result}, {Locals.Result}.Next, {node});"),
                                () => CS.Line($"{Locals.Result} = Result.Success({Cfg.CurName}, {Cfg.CurName}, {node});"));
                        }
                    });
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                CS.IndentInOut(
                    "InlineExpression",
                    () => CS.Line($"{Locals.Result} = {Cfg.Capa(expression.Rule.Identifier)}({Cfg.CurName});"));
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
                            $"{Locals.Result}.IsSuccess",
                            () => CS.Line($"{Locals.Result} = Result.Fail({Cfg.CurName});"),
                            () => CS.Line($"{Locals.Result} = Result.Success({Locals.Result}, {Cfg.CurName});"));
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
                            $"{Locals.Result}.IsSuccess",
                            () =>
                            {
                                CS.Line($"{Locals.Result} = Result.Success({Locals.Result}, {Cfg.CurName});");
                            },
                            () =>
                            {
                                CS.Line($"{Locals.Result} = Result.Fail({Cfg.CurName});");
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
                                    CS.Line($"{Locals.Result} = Result.Success({node}, {next}, {node});");
                                }
                            },
                            () =>
                            {
                                CS.Line($"{Locals.Result} = Result.Fail({Cfg.CurName});");
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
                            $"{Locals.Result}.IsSuccess",
                            () =>
                            {
                                using (var value = Locals.Use("value"))
                                using (var node = Locals.Use("node"))
                                {
                                    CS.Line($"{value} = string.Join(string.Empty, {Locals.Result}.Nodes.Select(n => n.Fuse()));");
                                    CS.Line($"{node} = Leaf.From({Locals.Result}, NodeSymbols.Fusion, {value});");
                                    CS.Line($"{Locals.Result} = Result.Success({Locals.Result}, {Locals.Result}.Next, {node});");
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
                        var array = String.Join(",", characters.Select(c => CharRep.InCSharp(c)));

                        using (var values = Locals.Use("values"))
                        {

                            CS.Line($"{values} = new int[]{{{array}}};");

                            var cond = expression.Negated
                                           ? "< 0"
                                           : ">= 0";
                            var check = characters.Count > 8
                                            ? $"_current => Array.BinarySearch({values}, _current) {cond}"
                                            : $"_current => Array.IndexOf({values}, _current) {cond}";

                            CS.Line($"{Locals.Result} = {Cfg.MatchPredicate}({Cfg.CurName}, {check});");
                        }
                    });
            }

            private void Space(Expression expression)
            {
                if (expression.Attr.IsWithSpacing)
                {
                    CS.Line($"{Cfg.CurName} = {Cfg.SkipSpace}({Cfg.CurName});");
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
                // handled by VisitClassExpression
                throw new NotImplementedException();
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                // handled by VisitClassExpression
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
                        writer.WriteLine($"{nameof(IResult)} {Name};");
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

            public static IDisposable PrepareResult()
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

            public static Local Result => results.Peek();

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
