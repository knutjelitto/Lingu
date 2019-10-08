﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface INonterminalToken : IToken
    {
        IReadOnlyList<IToken> Children { get; }
        IToken this[int childIndex] { get; }
    }
}
