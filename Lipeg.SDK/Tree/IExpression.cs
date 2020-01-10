using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public interface IExpression : ILocated
    {
        IExpressionAttributes Attr { get; }
    }
}
