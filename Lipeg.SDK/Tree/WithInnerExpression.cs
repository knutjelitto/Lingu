using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public abstract class WithInnerExpression : Expression, IInnerExpression
    {
        protected internal WithInnerExpression(ILocated located, Expression expression)
            : base(located)
        {
            Expression = expression;
        }

        public Expression Expression { get; }
    }
}
