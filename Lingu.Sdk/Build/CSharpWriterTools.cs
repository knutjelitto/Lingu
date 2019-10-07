using System.Collections.Generic;

using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Build
{
    public class CSharpWriterTools
    {
        protected const int extendWidth = 120;

        public CSharpWriterTools(Grammar grammar)
        {
            Grammar = grammar;
        }

        protected Grammar Grammar { get; }

        protected string Bool(bool b) => b ? "true" : "false";

        protected void WriteExtend(IndentWriter writer, IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                if (writer.Extend() > 0)
                {
                    writer.Write(" ");
                }
                writer.Write($"{value},");
                if (writer.Extend() >= extendWidth)
                {
                    writer.WriteLine();
                }
            }
            if (writer.Extend() > 0 && writer.Extend() < extendWidth)
            {
                writer.WriteLine();
            }
        }

        protected void WriteMany(IndentWriter writer, int perLine, IEnumerable<string> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                writer.Write($"{value},");
                count += 1;
                if (count == perLine)
                {
                    writer.WriteLine();
                    count = 0;
                }
            }
            if (count > 0)
            {
                writer.WriteLine();
            }
        }
    }
}
