using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ISource
    {
        char this[int index] { get; }

        string Name { get; }

        (int lineNo, int colNo) GetLineCol(int index);
        bool IsEnd(int index);
    }
}
