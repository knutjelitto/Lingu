using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Automata;
using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Repeat : Node, IExpression
    {
        private Repeat(IExpression expression, RepeatKind kind, int? min = null, int? max = null)
        {
            Expression = expression;
            Kind = kind;
            Min = min;
            Max = max;
        }

        public IExpression Expression { get; }
        public int? Min { get; }
        public int? Max { get; }
        public RepeatKind Kind { get; }
        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public static IExpression Star(IExpression expression)
        {
            return new Repeat(expression, RepeatKind.Star, 0);
        }

        public static IExpression Plus(IExpression expression)
        {
            return new Repeat(expression, RepeatKind.Plus, 1);
        }

        public static IExpression Optional(IExpression expression)
        {
            return new Repeat(expression, RepeatKind.Optional, 0, 1);
        }

        public static IExpression From(IExpression expression, int? min = null, int? max = null)
        {
            if (min == 1 && max == 1)
            {
                return expression;
            }

            RepeatKind kind;

            if (min == 0 && max == 1)
            {
                kind = RepeatKind.Optional;
            }
            else if (min == 0 && max == null)
            {
                kind = RepeatKind.Star;
            }
            else if (min == 1 && max == null)
            {
                kind = RepeatKind.Plus;
            }
            else
            {
                kind = RepeatKind.Special;
            }

            return new Repeat(expression, kind, min, max);
        }

        public FA GetFA()
        {
            return GetNfa(Expression);
        }

        public FA GetNfa(IExpression expression)
        {
            var expr = expression.GetFA();

            switch (Kind)
            {
                case RepeatKind.Optional:
                    return expr.Opt();
                case RepeatKind.Star:
                    return expr.Star();
                case RepeatKind.Plus:
                    return expr.Plus();
                case RepeatKind.Special:
                    {
                        var nfa = expr;
                        var i = 1;
                        for (; i < Min; ++i)
                        {
                            nfa = nfa.And(expr);
                        }
                        expr = expr.Opt();
                        for (; i < Max; ++i)
                        {
                            nfa = nfa.And(expr);
                        }
                        return nfa;
                    }
            }

            throw new ArgumentOutOfRangeException(nameof(expression));
        }

        public override void Dump(IndentWriter writer)
        {
            Expression.Dump(writer);
            writer.Write($"{Rep()}");
        }

        public string Rep()
        {
            switch (Kind)
            {
                case RepeatKind.Optional:
                    return "?";
                case RepeatKind.Star:
                    return "*";
                case RepeatKind.Plus:
                    return "+";
                case RepeatKind.Special:
                    {
                        if (Min == Max)
                            return $"{{{Min}}}";
                        return $"{{{Min},{Max}}}";
                    }
                default:
                    return string.Empty;
            }
        }
    }
}
