using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public interface IExpressionAttributes
    {
        bool IsNullable { get; }
        bool SetIsNullable();
        bool IsTerminal { get; }
        bool SetIsTerminal();
    }
}
