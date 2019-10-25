using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class LabeledExpression : Expression
    {
        private LabeledExpression(Identifier identifier, Expression expression)
        {
            Identifier = identifier;
            Expression = expression;
        }
        public Identifier Identifier { get; }
        public Expression Expression { get; }

        public static LabeledExpression From(Identifier identifier, Expression expression)
        {
            return new LabeledExpression(identifier, expression);
        }
    }
}
