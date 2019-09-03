using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void StateCountShouldBeKnown()
        {
            // "abc"
            var matcher = MakeMatcher("abc");

            Assert.AreEqual(4, matcher.FA.States.Count);
        }

        [TestMethod]
        public void CheckMatches()
        {
            // "abc"
            var matcher = MakeMatcher("abc");

            Assert.IsTrue(matcher.FullMatch("abc"));
        }

        [TestMethod]
        public void CheckMisMatches()
        {
            // "abc"
            var matcher = MakeMatcher("abc");

            Assert.IsFalse(matcher.FullMatch(" abc"));
            Assert.IsFalse(matcher.FullMatch("abc "));
            Assert.IsFalse(matcher.FullMatch("ab c"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyStringShouldThrow()
        {
            // "abc"
            MakeMatcher("");
        }

        private static Matcher MakeMatcher(string sequence)
        {
            var nfa = (FA) sequence;

            return new Matcher(nfa.ToDfa().Minimize());
        }
    }
}
