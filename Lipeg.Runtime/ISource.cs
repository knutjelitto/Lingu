using System;

namespace Lipeg.Runtime
{
    public interface ISource
    {
        char this[int index] { get; }
        string Name { get; }
        (int lineNo, int colNo) GetLineCol(int index);
        string GetText(int start, int length);
        bool AtEnd(int offset);

        ReadOnlySpan<char> Part(int offset, int lenght);

    }
}
