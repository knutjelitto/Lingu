using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public struct DCursor : ICursor
    {
        private readonly ISource source;
        private readonly int offset;

        private DCursor(ISource source, int offset)
        {
            this.source = source;
            this.offset = offset;
        }

        public ISource Source => source;

        public int Offset => offset;

        public ICursor Advance(int count)
        {
            return new DCursor(this.source, this.offset + 1);
        }

        public static ICursor Start(ISource source)
        {
            return new DCursor(source, 0);
        }
    }
}
