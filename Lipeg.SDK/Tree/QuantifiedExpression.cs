using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class QuantifiedExpression : Expression
    {
        private QuantifiedExpression(Expression expression, Quantifier quantifier)
        {
            Expression = expression;
            Quantifier = quantifier;
        }
        public Expression Expression { get; }
        public Quantifier Quantifier { get; }

        public static QuantifiedExpression From(Expression expression, Quantifier quantifier)
        {
            return new QuantifiedExpression(expression, quantifier);
        }
    }
}
