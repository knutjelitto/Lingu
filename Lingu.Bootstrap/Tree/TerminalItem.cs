﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public abstract class TerminalItem : NamedNode
    {
        public TerminalItem(AtomName name)
            : base(name)
        {
        }
    }
}
