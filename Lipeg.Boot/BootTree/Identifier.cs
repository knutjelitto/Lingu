using System;
using System.Collections.Generic;
using System.Text;
using Pegasus.Common;

namespace Lipeg.Boot.BootTree
{
    public class Identifier
    {
        private Identifier(string name, Cursor start, Cursor end)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Start = start;
            End = end;
        }
        public string Name { get; }
        public Cursor End { get; }
        public Cursor Start { get; }

        public static Identifier From(string name, Cursor start, Cursor end)
        {
            return new Identifier(name, start, end);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}
