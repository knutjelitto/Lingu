﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ILexer
    {
        bool IsEnd();
        ITerminalToken? Next(int stateId);
    }
}
