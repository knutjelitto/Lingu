using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Automata;

namespace Lingu.Check
{
    public class DfaChecker
    {
        public void Check()
        {
            Check1();
        }

        private void Check1()
        {
            // [0]|[1-9][0-9]*
            var zero = (FA)'0';
            var nonZero = (FA)('1', '9');
            var digit = (FA)('0', '9');

            var nfa = zero | (nonZero + digit.Star());

            var dfa = nfa.ToDfa().Minimize();

            dfa.Dump("", Console.Out);
        }

        private void Check2()
        {
            // .*[A-Z]|.*[0-9]
            var dot = FA.Any;

            var nfa = (dot.Star() + ('A', 'Z')) | (dot.Star() + ('0', '9'));

            nfa.Dump("", Console.Out);

            var dfa = nfa.ToDfa().Minimize();

            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
        }

        private void Check3()
        {
            // .*[A-Z].+|.*[0-9].+
            var dot = FA.Any;

            var nfa = (dot.Star() + ('A', 'Z') + dot.Plus()) | (dot.Star() + ('0', '9') + dot.Plus());

            nfa.Dump("", Console.Out);

            var dfa = nfa.ToDfa();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
            dfa = dfa.Minimize();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
        }

        private void Check4()
        {
            // .*[0-5]|.*[4-9]
            var dot = FA.Any;

            var nfa = (dot.Star() + ('0', '5') + dot.Plus()) | (dot.Star() + ('4', '9') + dot.Plus());

            nfa.Dump("", Console.Out);

            var dfa = nfa.ToDfa();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
            dfa = dfa.Minimize();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
        }

        private void Check5()
        {
            var a = (FA)'a';
            var b = (FA)'b';
            var c = (FA)'c';

            var nfa = (a.Plus() + b.Plus() + c.Plus()).Plus() | (a + b + c);

            nfa.Dump("", Console.Out);

            var dfa = nfa.ToDfa();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
            dfa = dfa.Minimize();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
        }

        private void Check6()
        {
            var nfa = (FA)"abc";

            nfa.Dump("", Console.Out);

            var dfa = nfa.ToDfa();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
            dfa = dfa.Minimize();
            Console.WriteLine("---------------");
            dfa.Dump("", Console.Out);
        }
    }
}
