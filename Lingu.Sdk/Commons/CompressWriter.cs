using System.Collections.Generic;

namespace Lingu.Commons
{
    public class CompressWriter
    {
        public byte[] Compress(IEnumerable<int> values)
        {
            var writer = new BinWriter();

            var zero = true;
            var zeroCount = 0;
            var nonZero= new List<int>();

            foreach (var value in values)
            {
                if (zero)
                {
                    if (value == 0)
                    {
                        zeroCount += 1;
                    }
                    else
                    {
                        writer.Write(zeroCount);
                        zeroCount = 0;
                        zero = false;
                        nonZero.Add(value);
                    }
                }
                else
                {
                    if (value != 0)
                    {
                        nonZero.Add(value);
                    }
                    else
                    {
                        writer.Write(nonZero.Count);
                        foreach (var nz in nonZero)
                        {
                            writer.Write(nz);
                        }
                        nonZero.Clear();
                        zero = true;
                        zeroCount = 1;
                    }
                }
            }
            if (zero)
            {
                writer.Write(zeroCount);
            }
            else
            {
                writer.Write(nonZero.Count);
                foreach (var nz in nonZero)
                {
                    writer.Write(nz);
                }
            }

            return writer.ToArray();
        }
    }
}
