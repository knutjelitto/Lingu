using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class SuffixExpression : WithInnerExpression
    {
        protected SuffixExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }
    }
}
