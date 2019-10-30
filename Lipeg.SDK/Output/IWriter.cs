using System;

namespace Lipeg.SDK.Output
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);

        void WriteLine();

        void Write(object something);

        void WriteLine(object somthing);

        void Indent(Action body);
    }
}
