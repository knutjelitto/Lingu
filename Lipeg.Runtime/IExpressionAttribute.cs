using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface IExpressionAttribute
    {
        bool Nullable { get; }
        bool SetNullable();
    }
}
