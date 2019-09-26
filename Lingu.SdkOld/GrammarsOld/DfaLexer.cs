﻿using Lingu.Automata;

namespace Lingu.GrammarsOld
{
    public class DfaLexer : Lexer
    {
        public DfaLexer(Terminal terminal, int offset)
            : base(terminal)
        {
            Offset = offset;
            Length = 0;
            Current = Dfa.Start;
        }

        public State Current { get; set; }

        public FA Dfa => ((DfaProvision) Provision).Dfa;

        public int Length { get; private set; }
        public int Offset { get; }

        public override bool Match(char @char)
        {
            foreach (var transition in Current.Transitions)
            {
                if (transition.Set.Contains(@char))
                {
                    Current = transition.Target;
                    Length += 1;
                    return true;
                }
            }

            return false;
        }

        public override bool IsFinal => Current.Final;

        public override string Finish(string input)
        {
            return input.Substring(Offset, Length);
        }
    }
}