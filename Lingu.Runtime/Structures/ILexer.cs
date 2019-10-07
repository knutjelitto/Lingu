using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ILexer
    {
        bool IsEnd();
        IConlex? First(int stateId);
        IConlex? Next(IConlex context, int stateId);
    }
}
