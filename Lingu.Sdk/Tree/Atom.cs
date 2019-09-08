﻿using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public abstract class Atom : Expression
    {
        public override IEnumerable<Expression> Children => Enumerable.Empty<Expression>();
    }
}