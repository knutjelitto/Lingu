using System.Collections.Generic;
using System.IO;

namespace Lingu.Commons
{
    public class BinWriter
    {
        private readonly MemoryStream stream;

        public BinWriter()
        {
            stream = new MemoryStream();
        }

        public byte[] ToArray()
        {
            return stream.ToArray();
        }

        public void Write(int value)
        {
            Write7BitEncodedInt(value);
        }
        public void Write(IEnumerable<int> intse)
        {
            foreach (var i in intse)
            {
                Write(i);
            }
        }

        public void Write(bool value)
        {
            WriteByte((byte)(value ? 1 : 0));
        }

        public void WriteByte(byte value)
        {
            stream.WriteByte(value);
        }

        protected void Write7BitEncodedInt(int value)
        {
            // Write out an int 7 bits at a time.  The high bit of the byte,
            // when on, tells reader to continue reading more bytes.
            uint v = (uint)value;   // support negative numbers
            while (v >= 0x80)
            {
                WriteByte((byte)(v | 0x80));
                v >>= 7;
            }
            WriteByte((byte)v);
        }
    }
}
