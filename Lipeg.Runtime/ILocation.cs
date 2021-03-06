﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ILocation : ILocated
    {
        ISource Source { get; }
        int Start { get; }
        int End { get; }
        int Length => End - Start;
    }
}
