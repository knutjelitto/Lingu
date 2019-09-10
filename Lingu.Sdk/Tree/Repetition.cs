using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Repetition : IExpression
    {
        public Repetition(IExpression expression, int? min = null, int? max = null)
        {
            Expression = expression;
            Min = min;
            Max = max;
        }

        public IExpression Expression { get; }
        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public int? Min { get; }
        public int? Max { get; }

        public FA GetFA()
        {
            var expr = Expression.GetFA();

            if (Min == 0 && Max == 1)
            {
                return expr.Opt();
            }
            if (Min == 0 && Max == null)
            {
                return expr.Star();
            }
            if (Min == 1 && Max == null)
            {
                return expr.Plus();
            }
            Debug.Assert(Min != null && Max != null);
            var nfa = expr;
            var i = 1;
            for (; i < Min; ++i)
            {
                nfa = nfa.Concat(expr);
            }
            expr = expr.Opt();
            for (; i < Max; ++i)
            {
                nfa = nfa.Concat(expr);
            }
            return nfa;
        }

        private string Rep
        {
            get
            {
                if (Min == 0 && Max == 1)
                    return "?";
                if (Min == 0 && Max == null)
                    return "*";
                if (Min == 1 && Max == null)
                    return "+";
                Debug.Assert(Min != null && Max != null);
                if (Min == Max)
                    return $"<{Min}>";
                return $"<{Min},{Max}>";
            }
        }

        public void Dump(IWriter output, bool top)
        {
            Expression.Dump(output, false);
            output.Write(Rep);
        }

        public IEnumerator<IExpression> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
