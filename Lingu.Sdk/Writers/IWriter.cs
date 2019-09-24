using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Writers
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);

        void WriteLine();

        void Write(object obj);

        void WriteLine(object obj);

        void Indend(Action body);
    }
}
