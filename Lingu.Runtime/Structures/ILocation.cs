using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ILocation
    {
        ISource Source { get; }
        int Offset { get; }
        int Length { get; }
    }
}
