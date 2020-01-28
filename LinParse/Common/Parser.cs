using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LinParse.Common
{
    public class Parser<T> where T : Lexer
    {
        protected readonly T lexer;

        public Parser(T lexer)
        {
            this.lexer = lexer;
        }

        public void Skip()
        {
            lexer.Skip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char At()
        {
            return lexer.At();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char At(int offset)
        {
            return lexer.At(offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char MatchAny()
        {
            var match = lexer.At();
            if (lexer.Current < lexer.Limit)
            {
                lexer.Current += 1;
                return match;
            }
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char Match(char ch)
        {
            if (lexer.Match(ch))
            {
                var match = lexer.At();
                lexer.Current += 1;
                return match;
            }
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Match(string vs)
        {
            if (lexer.Match(vs))
            {
                lexer.Current += vs.Length;
                return;
            }
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckHexDigit()
        {
            var digit = At();
            return '0' <= digit && digit <= '9' || 'a' <= digit && digit <= 'f' || 'A' <= digit && digit <= 'F';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char MatchHexDigit()
        {
            if (CheckHexDigit())
            {
                return MatchAny();
            }
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckDigit()
        {
            var digit = At();
            return '0' <= digit && digit <= '9';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char MatchDigit()
        {
            if (CheckDigit())
            {
                return MatchAny();
            }
            throw new NotImplementedException();
        }

        public bool CheckOneOf(params char[] vs)
        {
            var ch = At();
            foreach (var v in vs)
            {
                if (v == ch)
                {
                    return true;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnsureMore()
        {
            lexer.EnsureMore();
        }

        public bool HaveMore()
        {
            return lexer.Current < lexer.Limit;
        }
    }
}
