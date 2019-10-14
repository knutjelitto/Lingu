#nullable enable

namespace Lingu.Runtime.Commons
{
    public abstract class ByteReader
    {
        private readonly byte[] bytes;
        private int offset;

        public ByteReader(byte[] bytes, int offset)
        {
            this.bytes = bytes;
            this.offset = offset;
        }

        protected bool ReadBool()
        {
            return ReadByte() != 0;
        }

        protected int ReadInt32()
        {
            return Read7BitEncodedInt();
        }

        private byte ReadByte()
        {
            return bytes[offset++];
        }

        private int Read7BitEncodedInt()
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
