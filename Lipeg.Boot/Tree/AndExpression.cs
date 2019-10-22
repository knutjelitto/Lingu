using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.Tree
{
    public class AndExpression : Expression
    {
        private AndExpression(Expression expression)
        {
            Expression = expression;
        }
        public Expression Expression { get; }

        public static AndExpression From(Expression expression)
        {
            return new AndExpression(expression);
        }
    }
}
