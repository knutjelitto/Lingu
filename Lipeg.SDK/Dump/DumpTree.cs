using System;
using System.Linq;

using Lipeg.SDK.Output;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using Lipeg.SDK.Checks;
using Lipeg.Runtime.Tools;

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
                    base.VisitGrammarSyntax();
                });
            }

            protected override void VisitGrammarLexical()
            {
                Writer.Block($"{OpSymbols.Lexical}", () =>
                {
                    base.VisitGrammarLexical();
                });
            }

            protected override void VisitRule(Rule rule)
            {
                Writer.WriteLine($"{rule.Identifier} =>");
                Writer.Indent(() =>
                {
                    VisitExpression(rule.Expression);
                });
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                if (top)
                {
                    foreach (var choice in expression.Choices)
                    {
                        Writer.Write("/ ");
                        VisitExpression(choice);
                        Writer.WriteLine();
                    }
                }
                else
                {
                    Writer.Write("(");
                    var more = false;
                    foreach (var choice in expression.Choices)
                    {
                        if (more)
                        {
                            Writer.Write(" / ");
                        }
                        VisitExpression(choice);
                        more = true;
                    }
                    Writer.Write(")");
                }
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                var isTop = top;

                if (!isTop)
                {
                    Writer.Write("(");
                }
                top = false;
                var more = false;
                foreach (var element in expression.Sequence)
                {
                    if (more)
                    {
                        Writer.Write(" ");
                    }
                    VisitExpression(element);
                    more = true;
                }

                if (!isTop)
                {
                    Writer.Write(")");
                }
                top = isTop;
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                Writer.Write($"{OpSymbols.And}(");
                base.VisitAndExpression(expression);
                Writer.Write($")");
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                Writer.Write($"{OpSymbols.Not}(");
                base.VisitNotExpression(expression);
                Writer.Write($")");
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                Writer.Write($"{OpSymbols.Lift}(");
                base.VisitLiftExpression(expression);
                Writer.Write($")");
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                Writer.Write($"{OpSymbols.Drop}(");
                base.VisitDropExpression(expression);
                Writer.Write($")");
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                Writer.Write($"{OpSymbols.Fuse}(");
                base.VisitFuseExpression(expression);
                Writer.Write($")");
            }

            protected override void VisitQuantifiedExpression(QuantifiedExpression expression)
            {
                Writer.Write("(");
                VisitExpression(expression.Expression);
                Writer.Write($"){expression.Quantifier}");
            }
        }
    }
}
