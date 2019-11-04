﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public interface ICompileError
    {
        ErrorCode Code { get; }
        string Message { get; }
    }
}