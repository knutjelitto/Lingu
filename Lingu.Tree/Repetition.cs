using Lingu.Automata;
using Lingu.Commons;
using System.Diagnostics;

namespace Lingu.Tree
{
    public class Repetition : Expression
    {
        public Repetition(Expression expression, int? min = null, int? max = null)
        {
            Expression = expression;
            Min = min;
            Max = max;
        }

        public Expression Expression { get; }
        public int? Min { get; }
        public int? Max { get; }

        public override Nfa GetNfa()
        {
            var expr = Expression.GetNfa();

            if (Min == 0 && Max == 1)
            {
                return expr.Opt;
            }
            if (Min == 0 && Max == null)
            {
                return expr.Star;
            }
            if (Min == 1 && Max == null)
            {
                return expr.Plus;
            }
            Debug.Assert(Min != null && Max != null);
            var nfa = expr;
            var i = 1;
            for (; i < Min; ++i)
            {
                nfa = nfa.Concat(expr);
            }
            expr = expr.Opt;
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

        public override void Dump(Indentable output, bool top)
        {
            Expression.Dump(output, false);
            output.Write(Rep);
        }
    }
}
