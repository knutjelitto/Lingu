using System;
using Lipeg.Runtime;

namespace Lipeg.Boot
{
    public class Lexer : ILexer
    {
        private Lexer(ISource source)
        {
            Source = source;
            Offset = 0;
        }

        public ISource Source { get; }
        public int Offset { get; private set; }

        public static ILexer From(ISource source)
        {
            return new Lexer(source);
        }

        public bool AtEnd()
        {
            return Source.AtEnd(Offset);
        }

        public bool Match(string chars)
        {
            if (Source.Part(Offset, chars.Length).SequenceEqual(chars))
            {
                Offset += chars.Length;
                return true;
            }

            return false;
        }

        public void Lex()
        {
            Skip();
        }

        private void Skip()
        {
            if (!AtEnd() && CanSkip())
            {
                Offset += 1;
            }
        }

        private bool CanSkip()
        {
            return false;
        }

        public bool Skip(Func<char, bool> predicate)
        {
            bool skipped = false;
            while (!AtEnd() && predicate(Source[Offset]))
            {
                Offset += 1;
                skipped = true;
            }
            return skipped;
        }

        public string Match()
        {
            var m = string.Empty;
            if (!AtEnd())
            {
                m = Source[Offset].ToString();
                Offset += 1;
            }
            return m;
        }

        public bool Is(Func<char, bool> predicate)
        {
            bool matched = false;
            if (!AtEnd())
            {
                if (predicate(Source[Offset]))
                {
                    Offset += 1;
                    matched = true;
                }
            }

            return matched;
        }
    }
}
