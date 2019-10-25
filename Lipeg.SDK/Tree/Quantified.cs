using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Quantified : Expression
    {
        private Quantified(Expression expression, Quantifier quantifier)
        {
            Expression = expression;
            Quantifier = quantifier;
        }
        public Expression Expression { get; }
        public Quantifier Quantifier { get; }

        public static Quantified From(Expression expression, Quantifier quantifier)
        {
            return new Quantified(expression, quantifier);
        }
    }
}
