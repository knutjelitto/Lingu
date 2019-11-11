using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public interface IExpressionAttributes
    {
        bool Nullable { get; }
        bool SetNullable();
    }
}
