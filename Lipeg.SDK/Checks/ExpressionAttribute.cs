using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Checks
{
    public class ExpressionAttribute : IExpressionAttribute
    {
        public bool Nullable { get; private set; }

        public bool SetNullable()
        {
            if (!Nullable)
            {
                return Nullable = true;
            }
            return false;
        }
    }
}
