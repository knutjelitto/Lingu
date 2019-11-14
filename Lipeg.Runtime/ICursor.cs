using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ICursor
    {
        ISource Source { get; }
        int Offset { get; }
        ICursor Advance(int count);
        int Current => Source[Offset];
        bool AtEnd => Source.AtEnd(Offset);
    }
}
