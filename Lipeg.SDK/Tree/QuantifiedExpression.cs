using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class QuantifiedExpression : WithInnerExpression
    {
        private QuantifiedExpression(ILocated located, Expression expression, Quantifier quantifier)
            : base(located, expression)
        {
            Quantifier = quantifier;
        }
        public Quantifier Quantifier { get; }

        public static QuantifiedExpression From(ILocated located, Expression expression, Quantifier quantifier)
        {
            return new QuantifiedExpression(located, expression, quantifier);
        }
    }
}
