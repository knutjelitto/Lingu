using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class CornerTests
    {
        [TestMethod]
        public void Automata1()
        {
            // .* [0-5] .* | .* [4-9] .*
            var dot = FA.Any();

            var nfa = (dot.Star() + ('0', '5') + dot.Plus()) | (dot.Star() + ('4', '9') + dot.Plus());

            var dfa = nfa.ToDfa();

            dfa = dfa.Minimize();

            Assert.AreEqual(6, dfa.States.Count);
        }

        [TestMethod]
        public void Automata2()
        {
            // .*[A-Z].+|.*[0-9].+
            var dotPlus = FA.Any().Plus();
            var dotStar = FA.Any().Star();
            var letter = (FA)('A', 'Z');
            var digits = (FA)('0', '9');

            var nfa = (dotStar + letter + dotPlus) | (dotStar + digits + dotPlus);

            var dfa = nfa.ToDfa();

            dfa = dfa.Minimize();

            Assert.AreEqual(5, dfa.States.Count);
        }

        [TestMethod]
        public void Automata3()
        {
            // [0]|[1-9][0-9]*
            var nfa = (FA)'0' | (('1', '9') + ((FA)('0', '9')).Star());


            var dfa = nfa.ToDfa();

            dfa = dfa.Minimize();

            Assert.AreEqual(3, dfa.States.Count);
        }


        [TestMethod]
        public void Automata4()
        {
            // (a+b+c+)+|abc
            var a = (FA)'a';
            var b = (FA)'b';
            var c = (FA)'c';

            var nfa = (a.Plus() + b.Plus() + c.Plus()).Plus() | (a + b + c);

            var dfa = nfa.ToDfa();

            dfa = dfa.Minimize();

            Assert.AreEqual(5, dfa.States.Count);
        }
    }
}