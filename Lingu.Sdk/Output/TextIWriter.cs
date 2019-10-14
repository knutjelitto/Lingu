using System;
using System.IO;

namespace Lingu.Output
{
    public class TextIWriter : IWriter
    {
        public TextIWriter(TextWriter writer)
        {
            Writer = writer;
        }

        public TextWriter Writer { get; }

        public void Indent(Action body)
        {
            body();
        }

        public void Write(string text)
        {
            Writer.Write(text);
        }

        public void Write(object obj)
        {
            Writer.Write(obj);
        }

        public void WriteLine(string text)
        {
            Writer.WriteLine(text);
        }

        public void WriteLine()
        {
            Writer.WriteLine();
        }

        public void WriteLine(object obj)
        {
            Writer.WriteLine(obj);
        }
    }
}
