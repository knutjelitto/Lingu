using System.Diagnostics;

using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Common;
using System;

namespace Lipeg.SDK.Dump
{
    public class DumpPpGrammar : IDump<Semantic>
    {
        public void Dump(IWriter writer, Semantic semantic)
        {
            var dumper = new DumpVisitor(writer, semantic, 0);

            dumper.VisitGrammar();
        }

        private class DumpVisitor : TreeVisitor
        {
            public DumpVisitor(IWriter writer, Semantic semantic, int verbosity)
                : base(semantic)
            {
                Writer = writer;
                Verbosity = verbosity;
            }

            public IWriter Writer { get; }
            public int Verbosity { get; }
            private int level;
            private int ruleCount;

            public override void VisitGrammar()
            {
                Writer.Block($"grammar {Grammar.Name}", () =>
                {
                    base.VisitGrammar();
                });
            }

            public override void VisitGrammarOptions()
            {
                Writer.Block($"{OpSymbols.Opts}", () =>
                {
                    base.VisitGrammarOptions();
                });
            }

            protected override void VisitOption(Option option)
            {
                Writer.WriteLine($"{option.Identifier} = {option.OptionValue.QualifiedIdentifier};");
            }

            protected override void VisitGrammarSyntaxRules()
            {
                Writer.Block($"{OpSymbols.Syntax}", () =>
                {
                    ruleCount = 0;
                    foreach (var rule in Grammar.SyntaxRules)
                    {
                        if (rule.Attr(Semantic).IsInline)
                        {
                            continue;
                        }
                        VisitRule(rule);
                    }
                });
            }

            protected override void VisitGrammarLexicalRules()
            {
                Writer.Block($"{OpSymbols.Lexical}", () =>
                {
                    ruleCount = 0;
                    foreach (var rule in Grammar.LexicalRules)
                    {
                        if (rule.Attr(Semantic).IsInline)
                        {
                            continue;
                        }
                        VisitRule(rule);
                    }
                });
            }

            protected override void VisitRule(IRule rule)
            {
                if (ruleCount > 0)
                {
                    Writer.WriteLine();
                }

                if (Verbosity > 1)
                {
                    Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsUsed)}is used");
                    Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsReachable)}is reachable");
                    Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsNullable)}is nullable");
                    Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsLexical)}is lexical");
                    Writer.WriteLine($"// {Not(rule.Attr(Semantic).IsSyntax)}is syntax");
                }
                Writer.WriteLine($"{rule.Identifier} {OpSymbols.DefPlain}");
                Writer.Indent(() =>
                {
                    this.level = 0;
                    VisitExpression(rule.Expression);
                    Writer.WriteLine(";");
                });
                ruleCount += 1;
            }


            public override void VisitExpression(Expression expression)
            {
                this.level++;
                base.VisitExpression(expression);
                if (this.level == 1)
                {
                    Writer.WriteLine();
                }
                this.level--;
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                if (this.level == 1)
                {
                    var more = false;
                    foreach (var choice in expression.Choices)
                    {
                        if (more)
                        {
                            Writer.WriteLine();
                        }
                        if (expression.Choices.Count > 1)
                        {
                            Writer.Write("/ ");
                        }
                        VisitExpression(choice);
                        more = true;
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
                var isTop = this.level == 1;

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
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                Writer.Write($"{OpSymbols.And}");
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                Writer.Write($"{OpSymbols.Not}");
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                Writer.Write($"{OpSymbols.Lift}");
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                Writer.Write($"{OpSymbols.Drop}");
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                Writer.Write($"{OpSymbols.Fuse}");
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
            }

            protected override void VisitOptionalExpression(OptionalExpression expression)
            {
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
                Writer.Write($"{OpSymbols.Option}");
            }

            protected override void VisitPlusExpression(PlusExpression expression)
            {
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
                Writer.Write($"{OpSymbols.Plus}");
            }

            protected override void VisitStarExpression(StarExpression expression)
            {
                MaybeParent(expression.Expression is PrefixExpression, expression.Expression);
                Writer.Write($"{OpSymbols.Star}");
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Writer.Write($"{expression.Identifier.Name}");
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                var rule = expression.InlineRule;

                Writer.WriteLine($"({rule.Identifier} {OpSymbols.DefPlain}");
                Writer.Indent(() =>
                {
                    VisitExpression(rule.Expression);
                    Writer.Write(")");
                });
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
#if true
                Debug.Assert(expression != null);
                write();
#else
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
#endif
            }

            private void MaybeParent(bool condition, Expression expression)
            {
                if (condition)
                {
                    Writer.Write("(");
                }
                VisitExpression(expression);
                if (condition)
                {
                    Writer.Write(")");
                }
            }
        }
    }
}
