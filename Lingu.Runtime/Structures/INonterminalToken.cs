﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface INonterminalToken : INonleafToken
    {
        INonterminal Nonterminal { get; }
    }
}
