using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class ABCTests
    {
        [TestMethod]
        public void ThereShouldBeFourDfaStates()
        {
            // a?b?c?
            var matcher = MakeMatcher();

            Assert.AreEqual(4, matcher.FA.States.Count);
        }

        [TestMethod]
        public void CheckMatches()
        {
            // a?b?c?
            var matcher = MakeMatcher();

            Assert.IsTrue(matcher.FullMatch(""));
            Assert.IsTrue(matcher.FullMatch("a"));
            Assert.IsTrue(matcher.FullMatch("ab"));
            Assert.IsTrue(matcher.FullMatch("ac"));
            Assert.IsTrue(matcher.FullMatch("b"));
            Assert.IsTrue(matcher.FullMatch("bc"));
            Assert.IsTrue(matcher.FullMatch("c"));
        }

        [TestMethod]
        public void CheckMisMatches()
        {
            // a?b?c?
            var matcher = MakeMatcher();

            Assert.IsFalse(matcher.FullMatch("aa"));
            Assert.IsFalse(matcher.FullMatch("ba"));
            Assert.IsFalse(matcher.FullMatch("x"));
        }

        private static Matcher MakeMatcher()
        {
            // a?b?c?
            var aaa = FA.From('a').Opt();
            var bbb = FA.From('b').Opt();
            var ccc = FA.From('c').Opt();

            var nfa = ((FA) 'a').Opt() + ((FA) 'b').Opt() + ((FA) 'c').Opt();

            return new Matcher(nfa.ToDfa().Minimize());
        }
    }
}
