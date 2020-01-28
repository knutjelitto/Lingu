using System;
using System.Runtime.CompilerServices;

namespace LinParse.Common
{
    public abstract class Lexer
    {
        public const char NoCharacter = '\uFFFF';

        private readonly Source source;
        protected readonly string content;
        public int Current;
        public int Limit;

        public Lexer(Source source)
        {
            this.source = source;
            content = source.Content;
            Current = 0;
            Limit = this.content.Length;
        }

        public SourceSpan Span(int start)
        {
            return new SourceSpan(source, start, Current - start);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Skip()
        {
            while (Current < Limit && CanSkip())
            {
                Current += 1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public abstract bool CanSkip();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Match(char what)
        {
            return Current < Limit && content[Current] == what;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Match(string what)
        {
            return content.AsSpan(Current, what.Length).Equals(what.AsSpan(), StringComparison.Ordinal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char At()
        {
            return Current < Limit ? content[Current] : NoCharacter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char At(int offset)
        {
            return Current + offset < Limit ? content[Current + offset] : NoCharacter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnsureMore()
        {
            if (Current < Limit)
            {
                return;
            }
            throw new NotImplementedException();
        }
    }
}
