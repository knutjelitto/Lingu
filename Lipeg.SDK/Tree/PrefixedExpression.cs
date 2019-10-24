using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class PrefixedExpression : Expression
    {
        private PrefixedExpression(Identifier identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
        public Identifier Identifier { get; }
        public Expression Expression { get; }

        public static PrefixedExpression From(Identifier identifier, Expression expression)
        {
            return new PrefixedExpression(identifier, expression);
        }
    }
}
