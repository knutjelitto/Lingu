using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class NotExpression : Expression
    {
        private NotExpression(Expression expression)
        {
            Expression = expression;
        }
        public Expression Expression { get; }

        public static NotExpression From(Expression expression)
        {
            return new NotExpression(expression);
        }
    }
}
