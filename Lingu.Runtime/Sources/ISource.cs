using System;

namespace Lingu.Runtime.Sources
{
    public interface ISource
    {
        string Name { get; }
        int Length { get; }

        string GetText(int start, int length);
        ReadOnlySpan<char> GetSpan(int start, int length);
        int GetLineIndex(int lineNo);
        ReadOnlySpan<char> GetLineContent(int lineNo);
    }
}
