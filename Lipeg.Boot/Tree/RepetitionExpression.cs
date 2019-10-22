using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.Tree
{
    public class RepetitionExpression : Expression
    {
        private RepetitionExpression(Expression expression, Quantifier quantifier)
        {
            Expression = expression;
            Quantifier = quantifier;
        }
        public Expression Expression { get; }
        public Quantifier Quantifier { get; }

        public static RepetitionExpression From(Expression expression, Quantifier quantifier)
        {
            return new RepetitionExpression(expression, quantifier);
        }
    }
}
