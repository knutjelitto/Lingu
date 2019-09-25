using System;
using System.Diagnostics;
using Lingu.Automata;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Structures;
using Lingu.Tree;

#nullable enable

namespace Lingu.Grammars
{
    public class Terminal : Symbol, ITerminal
    {
        public Terminal(string name)
            : base(name)
        {
            Visual = string.Empty;
            lazyDfa = new Lazy<Dfa>(() => GetDfa().Convert());
            Raw = RawTerminal.Nope;
        }

        public Dfa Dfa => lazyDfa.Value;
        public string Visual { get; set; }
        public RawTerminal Raw { get; set; }

        private readonly Lazy<Dfa> lazyDfa;

        public FA GetDfa()
        {
            Debug.Assert(Raw != null);
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
