using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ILexer
    {
        //bool AtEnd();
        IConlex? First();
        IConlex? Next(IConlex context);
    }
}
