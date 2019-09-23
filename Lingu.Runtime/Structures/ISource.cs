using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ISource
    {
        char this[int index] { get; }
        bool IsEnd(int index);
    }
}
