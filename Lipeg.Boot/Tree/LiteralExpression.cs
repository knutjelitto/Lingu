using System;
using System.Collections.Generic;
using System.Text;
using Pegasus.Common;

namespace Lipeg.Boot.Tree
{
    public class LiteralExpression : Expression
    {
        private LiteralExpression(Cursor start, Cursor end, string value, bool? ignoreCase, bool fromResource)
        {
            Start = start;
            End = end;
            Value = value;
            IgnoreCase = ignoreCase;
            FromResource = fromResource;
        }

        public static LiteralExpression From(Cursor start, Cursor end, string value, bool? ignoreCase = null, bool fromResource = false)
        {
            return new LiteralExpression(start, end, value, ignoreCase, fromResource);
        }

        public Cursor Start { get; }
        public Cursor End { get; }
        public string Value { get; }
        public bool? IgnoreCase { get; }
        public bool FromResource { get; }
    }
}
