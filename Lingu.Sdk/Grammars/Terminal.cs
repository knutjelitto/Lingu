using System;

using Lingu.Automata;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Structures;
using Lingu.Tree;

namespace Lingu.Grammars
{
    public class Terminal : Symbol, ITerminal
    {
        public Terminal(string name)
            : base(name)
        {
        }

        public Dfa Dfa { get; set; }
        public byte[] Bytes { get; set; }
        public string Visual { get; set; }
        public RawTerminal Raw { get; set; }
        public FA GetDfa()
        {
            return Raw.Expression.GetFA().ToDfa().Minimize().RemoveDead();
        }

        public override string ToString()
        {
            if (IsGenerated && !string.IsNullOrEmpty(Visual))
            {
                return $"'{Visual}'";
            }
            return $"ˈ{Name}ˈ";
        }

        public override string ToShort()
        {
            if (IsGenerated && !string.IsNullOrEmpty(Visual))
            {
                return $"{Visual}";
            }
            return $"{Name}";
        }
    }
}
