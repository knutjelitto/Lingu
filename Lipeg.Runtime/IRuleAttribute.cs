using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface IRuleAttribute
    {
        int UseCount { get; }
        void Use();
        bool Used => UseCount > 0;
    }
}
