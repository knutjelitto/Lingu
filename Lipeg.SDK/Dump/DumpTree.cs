using System.Diagnostics;

using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Common;
using System;

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

            protected override void VisitGrammarSyntaxRules()
            {
                Writer.Block($"{OpSymbols.Syntax}", () =>
                {
                    ruleCount = 0;
                    base.VisitGrammarSyntaxRules();
                });
            }

            protected override void VisitGrammarLexicalRules()
            {
                Writer.Block($"{OpSymbols.Lexical}", () =>
                {
                    ruleCount = 0;
                    base.VisitGrammarLexicalRules();
                });
            }

            protected override void VisitRule(IRule rule)
            {
                if (ruleCount > 0)
                {
                    Writer.WriteLine();
                }

                Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsUsed)}used somewhere");
                Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsReachable)}reachable from start");
                Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsNullable)}zeroable");
                Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsLexical)}behave lexical");
                Writer.WriteLine($"{rule.Identifier} {OpSymbols.DefPlain}");
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

            protected override void VisitOptionalExpression(OptionalExpression expression)
            {
                base.VisitOptionalExpression(expression);
                Writer.Write($"{OpSymbols.Option}");
            }

            protected override void VisitPlusExpression(PlusExpression expression)
            {
                base.VisitPlusExpression(expression);
                Writer.Write($"{OpSymbols.Plus}");
            }

            protected override void VisitStarExpression(StarExpression expression)
            {
                base.VisitStarExpression(expression);
                Writer.Write($"{OpSymbols.Star}");
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Writer.Write($"{expression.Identifier.Name}");
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Writer.Write($"{expression.Rule.Identifier.Name}");
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                void Write()
                {
                    Writer.Write("[");
                    foreach (var choice in expression.Choices)
                    {
                        VisitExpression(choice);
                    }
                    Writer.Write("]");
                }

                LexSpaced(expression, Write);
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                void Write()
                {
                    Writer.Write($"'{CharRep.InText(expression.Value)}'");
                }

                LexSpaced(expression, Write);
            }

            protected override void VisitAnyExpression(AnyExpression expression)
            {
                void Write()
                {
                    Writer.Write($"{OpSymbols.Any}");
                }

                LexSpaced(expression, Write);
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                Writer.Write($"{expression.Value.InClass()}");
            }

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                Writer.Write($"{expression.Min.InClass()}-{expression.Max.InClass()}");
            }

            private string Not(bool value)
            {
                return value ? string.Empty : "! ";
            }

            private void LexSpaced(Expression expression, Action write)
            {
                var strip = expression.Attr(Semantic).IsLexical && !expression.Attr(Semantic).Rule.Attr(Semantic).IsLexical;

                if (strip)
                {
                    Writer.Write("(_ ");
                }
                write();
                if (strip)
                {
                    Writer.Write(")");
                }
            }
        }
    }
}
