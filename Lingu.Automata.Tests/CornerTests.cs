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

            var nfa = FA.Or(
                FA.And(dot.Star(), FA.From('0', '5'), dot.Plus()),
                FA.And(dot.Star(), FA.From('4', '9'), dot.Plus()));

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
            var letter = FA.From('A', 'Z');
            var digits = FA.From('0', '9');

            var nfa = FA.Or(
                FA.And(dotStar, letter, dotPlus),
                FA.And(dotStar, digits, dotPlus));

            var dfa = nfa.ToDfa();

            dfa = dfa.Minimize();

            Assert.AreEqual(5, dfa.States.Count);
        }

        [TestMethod]
        public void Automata3()
        {
            // [0]|[1-9][0-9]*
            var nfa = FA.Or(
                FA.From('0'),
                FA.And(FA.From('1', '9'), FA.From('0', '9').Star()));


            var dfa = nfa.ToDfa();

            dfa = dfa.Minimize();

            Assert.AreEqual(3, dfa.States.Count);
        }


        [TestMethod]
        public void Automata4()
        {
            // (a+b+c+)+|abc
            var a = FA.From('a');
            var b = FA.From('b');
            var c = FA.From('c');

            var nfa = FA.Or(
                FA.And(a.Plus(), b.Plus(), c.Plus()).Plus(),
                FA.And(a, b, c));

            var dfa = nfa.ToDfa();

            dfa = dfa.Minimize();

            Assert.AreEqual(5, dfa.States.Count);
        }
    }
}