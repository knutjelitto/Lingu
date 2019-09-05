using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class CrLfTests
    {
        [TestMethod]
        public void ThereShouldBeThreeDfaStates()
        {
            // [ab]?[abc][ab]?
            var matcher = Matcher();

            Assert.AreEqual(3, matcher.FA.States.Count);
        }

        [TestMethod]
        public void CheckLength2()
        {
            var matcher = Matcher();

            Assert.IsTrue(matcher.FullMatch("l"));
            Assert.IsFalse(matcher.FullMatch("ll"));
            Assert.IsFalse(matcher.FullMatch("lc"));
            Assert.IsFalse(matcher.FullMatch("c"));
            Assert.IsFalse(matcher.FullMatch("cc"));
            Assert.IsTrue(matcher.FullMatch("cl"));
            Assert.IsFalse(matcher.FullMatch("ccl"));
        }

        private static Matcher Matcher()
        {
            // lf | cr lf
            var start = new State();
            var cr = new State();
            var done = new State();

            var l = Codepoints.From('l');
            var c = Codepoints.From('c');

            start.Add(l, done);
            start.Add(c, cr);
            cr.Add(l, done);

            var nfa = FA.From(start, done);

            return new Matcher(nfa.ToDfa().Minimize());
        }
    }
}
