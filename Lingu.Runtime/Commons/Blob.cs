using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lingu.Runtime.Commons
{
    public static class Blob
    {
        public static byte[] ToCompressedBytes(IEnumerable<ushort> ushorts)
        {
            Debug.Assert(ushorts != null);

            using (var binWriter = new BinWriter())
            {
                foreach (var coded in ushorts)
                {
                    binWriter.Write(coded);
                }
                var bytes = binWriter.ToArray();
                var memory = new MemoryStream();
                var deflate = new DeflateStream(memory, CompressionLevel.Optimal);
                deflate.Write(bytes);
                deflate.Close();
                var compressed = memory.ToArray();

                return compressed;
            }
        }
    }
}
