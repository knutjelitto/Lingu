using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Commons
{
    public class BinReader
    {
        private readonly byte[] bytes;
        private int offset;

        public BinReader(byte[] bytes)
        {
            this.bytes = bytes;
            offset = 0;
        }

        public byte ReadByte()
        {
            return bytes[offset++];
        }

        protected int Read7BitEncodedInt()
        {
            // Read out an Int32 7 bits at a time.  The high bit
            // of the byte when on means to continue reading more bytes.
            int count = 0;
            int shift = 0;
            byte b;
            do
            {
                // ReadByte handles end of stream cases for us.
                b = ReadByte();
                count |= (b & 0x7F) << shift;
                shift += 7;
            } while ((b & 0x80) != 0);
            return count;
        }
    }
}
