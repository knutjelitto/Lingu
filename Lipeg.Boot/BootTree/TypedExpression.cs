using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class TypedExpression : Expression
    {
        private TypedExpression(CodeSpan type, Expression expression)
        {
            Type = type;
            Expression = expression;
        }
        public CodeSpan Type { get; }
        public Expression Expression { get; }

        public static TypedExpression From(CodeSpan type, Expression expression)
        {
            return new TypedExpression(type, expression);
        }

    }
}
