﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ICursor
    {
        ISource Source { get; }
        int Offset { get; }
    }
}
