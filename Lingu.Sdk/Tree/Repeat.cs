using System.Diagnostics;

using Lingu.Automata;

namespace Lingu.Tree
{
    public class Repeat
    {
        public Repeat(int? min = null, int? max = null)
        {
            Min = min;
            Max = max;
        }

        public int? Min { get; }
        public int? Max { get; }

        public FA GetNfa(IExpression expression)
        {
            var expr = expression.GetFA();

            if (Min == 1 && Max == 1)
            {
                return expr;
            }
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

        public override string ToString()
        {
            if (Min == 1 && Max == 1)
                return string.Empty;
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
}
