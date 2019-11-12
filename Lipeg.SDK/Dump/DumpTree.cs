using System.Diagnostics;

using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Common;

namespace Lipeg.SDK.Dump
{
    public class DumpTree : IDump<Semantic>
    {
        public void Dump(IWriter writer, Semantic semantic)
        {
            var dumper = new DumpVisitor(semantic, writer);

            dumper.VisitGrammar();
        }

        private class DumpVisitor : TreeVisitor
        {
            public DumpVisitor(Semantic semantic, IWriter writer)
                : base(semantic)
            {
                Writer = writer;
            }

            public IWriter Writer { get; }
            private bool top = true;
            private int ruleCount = 0;

            public override void VisitGrammar()
            {
                Writer.Block($"grammar {Grammar.Name}", () =>
                {
                    base.VisitGrammar();
                });
            }

            public override void VisitGrammarOptions()
            {
                Writer.Block($"{OpSymbols.Options}", () =>
                {
                    base.VisitGrammarOptions();
                });
            }

            protected override void VisitOption(Option option)
            {
                Writer.WriteLine($"{option.Identifier} = {option.QualifiedIdentifier};");
            }

            protected override void VisitGrammarSyntax()
            {
                Writer.Block($"{OpSymbols.Syntax}", () =>
                {
                    ruleCount = 0;
                    base.VisitGrammarSyntax();
                });
            }

            protected override void VisitGrammarLexical()
            {
                Writer.Block($"{OpSymbols.Lexical}", () =>
                {
                    ruleCount = 0;
                    base.VisitGrammarLexical();
                });
            }

            protected override void VisitRule(Rule rule)
            {
                if (ruleCount > 0) Writer.WriteLine();
                if (Semantic[rule].Nullable)
                {
                    Writer.WriteLine("// nullable");
                }
                if (!Semantic[rule].Reachable)
                {
                    Writer.WriteLine("// !reachable");
                }
                Writer.WriteLine($"{rule.Identifier} =>");
                if (rule.Identifier.Name == "identifier")
                {
                    Debug.Assert(true);
                }
                Writer.Indent(() =>
                {
                    VisitExpression(rule.Expression);
                    Writer.WriteLine(";");
                });
                ruleCount += 1;
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                if (top)
                {
                    foreach (var choice in expression.Choices)
                    {
                        if (expression.Choices.Count > 1)
                        {
                            Writer.Write("/ ");
                        }
                        VisitExpression(choice);
                        Writer.WriteLine();
                    }
                }
                else
                {
                    var more = false;
                    if (expression.Choices.Count > 1)
                    {
                        Writer.Write("(");
                    }
                    foreach (var choice in expression.Choices)
                    {
                        if (more)
                        {
                            Writer.Write(" / ");
                        }
                        VisitExpression(choice);
                        more = true;
                    }
                    if (expression.Choices.Count > 1)
                    {
                        Writer.Write(")");
                    }
                }
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                var isTop = top;

                top = false;
                var more = false;
                if (!isTop && expression.Sequence.Count > 1)
                {
                    Writer.Write("(");
                }
                foreach (var element in expression.Sequence)
                {
                    if (more)
                    {
                        Writer.Write(" ");
                    }
                    
                    VisitExpression(element);
                    more = true;
                }
                if (!isTop && expression.Sequence.Count > 1)
                {
                    Writer.Write(")");
                }

                top = isTop;
            }

            protected override void VisitAliasExpression(AliasExpression expression)
            {
                VisitExpression(expression.Expression);
                Writer.Write($":{expression.Alias.Name}");
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                Writer.Write($"{OpSymbols.And}");
                VisitExpression(expression.Expression);
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                Writer.Write($"{OpSymbols.Not}");
                VisitExpression(expression.Expression);
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                Writer.Write($"{OpSymbols.Lift}");
                VisitExpression(expression.Expression);
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                Writer.Write($"{OpSymbols.Drop}");
                VisitExpression(expression.Expression);
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                Writer.Write($"{OpSymbols.Fuse}");
                VisitExpression(expression.Expression);
            }

            protected override void VisitQuantifiedExpression(QuantifiedExpression expression)
            {
                VisitExpression(expression.Expression);
                Writer.Write($"{expression.Quantifier}");
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Writer.Write($"{expression.Identifier.Name}");
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                Writer.Write($"{expression.Value.InClass()}");
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                Writer.Write("[");
                foreach (var part in expression.Parts)
                {
                    VisitExpression(part);
                }
                Writer.Write("]");
            }

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                Writer.Write($"{expression.Min.InClass()}-{expression.Max.InClass()}");
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                Writer.Write($"'{CharRep.InText(expression.Value)}'");
            }

            protected override void VisitWildcardExpression(WildcardExpression expression)
            {
                Writer.Write($"{OpSymbols.Any}");
            }
        }
    }
}
