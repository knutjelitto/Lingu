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
    public class RepeatList : Node, IExpression
    {
        private RepeatList(IExpression expression, IExpression separator, RepeatKind kind)
        {
            Expression = expression;
            Separator = separator;
            Kind = kind;
        }

        public IExpression Expression { get; }
        public IExpression Separator { get; }
        public RepeatKind Kind { get; }
        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public static IExpression Star(IExpression expression, IExpression separator)
        {
            return new RepeatList(expression, separator, RepeatKind.StarList);
        }

        public static IExpression Plus(IExpression expression, IExpression separator)
        {
            return new RepeatList(expression, separator, RepeatKind.PlusList);
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
                case RepeatKind.Star:
                    return expr.Star();
                case RepeatKind.Plus:
                    return expr.Plus();
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
                case RepeatKind.Star:
                    return "*:";
                case RepeatKind.Plus:
                    return "+:";
                default:
                    return string.Empty;
            }
        }
    }
}
