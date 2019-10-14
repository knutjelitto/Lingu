using System;
using System.IO;

namespace Lingu.Runtime.Commons
{
    public class BinWriter : IDisposable
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

        public void Write(bool value)
        {
            WriteByte((byte)(value ? 1 : 0));
        }

        protected void WriteByte(byte value)
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

        #region IDisposable Support
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    stream.Dispose();
                }

                disposed = true;
            }
        }

        ~BinWriter()
        {
          // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
          Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
