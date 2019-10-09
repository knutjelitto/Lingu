using System;
using System.Collections.Generic;
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
            var binWriter = new BinWriter();
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

        public static ushort[] UInt16FromCompressedBytes(int uncompressed, int n, byte[] bytes)
        {
            var memory = new MemoryStream(bytes);
            var deflate = new DeflateStream(memory, CompressionMode.Decompress);
            var buffer = new byte[uncompressed];
            deflate.Read(buffer, 0, uncompressed);
            deflate.Close();
            memory.Close();
            var binReader = new BinReader(buffer);
            var ushorts = new ushort[n];
            for (var i = 0; i < n; ++i)
            {
                ushorts[i] = (ushort)binReader.ReadInt32();
            }

            return ushorts;
        }

        public static byte[] ToBytes2(IEnumerable<ushort> ushorts)
        {

            IFormatter formatter = new BinaryFormatter();
            byte[] bytes;
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ushorts.ToArray());
                stream.Close();
                bytes = stream.ToArray();
            }

            return bytes;
        }

    }
}
