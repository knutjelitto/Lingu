using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void ThereShouldBeThreeDfaStates()
        {
            // a?[ab]
            var matcher = MakeMatcher();

            Assert.AreEqual(3, matcher.FA.States.Count);
        }


        [TestMethod]
        public void CheckLength1()
        {
            // a?[ab]
            var matcher = MakeMatcher();

            Assert.IsTrue(matcher.FullMatch("a"), "should match 'a'");
            Assert.IsTrue(matcher.FullMatch("b"), "should match 'b'");
        }

        [TestMethod]
        public void CheckLength2()
        {
            // a?[ab]
            var matcher = MakeMatcher();

            Assert.IsTrue(matcher.FullMatch("aa"));
            Assert.IsTrue(matcher.FullMatch("ab"));
        }

        [TestMethod]
        public void CheckMisMatches()
        {
            // a?[ab]
            var matcher = MakeMatcher();

            Assert.IsFalse(matcher.FullMatch(""));
            Assert.IsFalse(matcher.FullMatch("aaa"));
            Assert.IsFalse(matcher.FullMatch("abc"));
        }

        private static Matcher MakeMatcher()
        {
            // a?[ab]
            var first = new State();
            var last = new State();
            var end = new State();

            var a1 = Integers.From('a');
            var a2 = Integers.From('a', 'b');

            first.Add(a1, last);
            first.Add(last);
            last.Add(a2, end);

            var nfa = FA.From(first, end);

            return new Matcher(nfa.ToDfa().Minimize());
        }
    }
}
