using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class PrefixExpression : WithInnerExpression
    {
        protected PrefixExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }
    }
}
