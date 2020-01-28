using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse.Common
{
    public struct SourceSpan
    {
        public SourceSpan(Source source, int start, int length)
        {
            Source = source;
            Start = start;
            Length = length;
        }

        public readonly Source Source;
        public readonly int Start;
        public readonly int Length;

        public ReadOnlySpan<char> Value => Source.Content.AsSpan(Start, Length);
    }
}
