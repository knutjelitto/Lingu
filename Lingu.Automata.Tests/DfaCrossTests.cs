using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class DfaCrossTests
    {
        [TestMethod]
        public void CheckEvenA()
        {
            var evenA = MatchEvenA();

            Assert.IsTrue(evenA.FullMatch(""));
            Assert.IsFalse(evenA.FullMatch("a"));
            Assert.IsTrue(evenA.FullMatch("aa"));
            Assert.IsTrue(evenA.FullMatch("baa"));
            Assert.IsTrue(evenA.FullMatch("aba"));
            Assert.IsTrue(evenA.FullMatch("aab"));
            Assert.IsFalse(evenA.FullMatch("aaa"));
            Assert.IsTrue(evenA.FullMatch("aaaa"));
        }

        [TestMethod]
        public void CheckEvenB()
        {
            var evenA = MatchEvenB();

            Assert.IsTrue(evenA.FullMatch(""));
            Assert.IsFalse(evenA.FullMatch("b"));
            Assert.IsTrue(evenA.FullMatch("bb"));
            Assert.IsTrue(evenA.FullMatch("abb"));
            Assert.IsTrue(evenA.FullMatch("bab"));
            Assert.IsTrue(evenA.FullMatch("bba"));
            Assert.IsFalse(evenA.FullMatch("bbb"));
            Assert.IsTrue(evenA.FullMatch("bbbb"));
        }

        private Dfa EvenA()
        {
            var start = new DfaState(true);
            var count = new DfaState(false);
            var a = Atom.From('a');
            var b = Atom.From('b');
            start.Add(b, start);
            start.Add(a, count);
            count.Add(b, count);
            count.Add(a, start);

            return Dfa.From(start);
        }

        private DfaMatcher MatchEvenA()
        {
            return new DfaMatcher(EvenA());
        }

        private Dfa EvenB()
        {
            var start = new DfaState(true);
            var count = new DfaState(false);
            var a = Atom.From('a');
            var b = Atom.From('b');
            start.Add(a, start);
            start.Add(b, count);
            count.Add(a, count);
            count.Add(b, start);

            return Dfa.From(start);
        }

        private DfaMatcher MatchEvenB()
        {
            return new DfaMatcher(EvenB());
        }
    }
}