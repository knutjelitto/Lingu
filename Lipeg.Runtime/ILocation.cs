using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ILocation
    {
        int Start { get; }
        int End { get; }
    }
}
