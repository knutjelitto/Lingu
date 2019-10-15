using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Commons
{
    public class CompressReader
    {
        public byte[] Uncompress(byte[] compressed)
        {
            var reader = new BinReader(compressed);

            var byteCount = reader.ReadInt32();
            var bytes = new byte[byteCount];

            bool zero = true;
            var pos = 0;
            while (reader.CanRead)
            {
                if (zero)
                {
                    var zeroCount = reader.ReadInt32();
                    for (var i = 0; i < zeroCount; ++i)
                    {
                        bytes[pos++] = 0;
                    }
                    zero = false;
                }
                else
                {
                    var count = reader.ReadInt32();
                    for (var i = 0; i < count; ++i)
                    {
                        bytes[pos++] = reader.ReadByte();
                    }
                    zero = true;
                }
            }

            return bytes;
        }
    }
}
