using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class NotAtomTests
    {
        [TestMethod]
        public void NotSingleCreateString()
        {
            var sut = Codepoints.From('a').Not();

            Assert.AreEqual("[0-96,98-1114111]", sut.ToIString());
        }

        [TestMethod]
        public void NotSingleShouldMatch()
        {
            var sut = Codepoints.From('a').Not();

            Assert.IsFalse(sut.Contains('a'));
        }

        [TestMethod]
        public void NotSingleShouldntMatch()
        {
            var sut = Codepoints.From('a').Not();

            Assert.IsTrue(sut.Contains('b'));
        }

        [TestMethod]
        public void NotRangeCreateString()
        {
            var sut = Codepoints.From('u', 'w').Not();

            Assert.AreEqual("[0-116,120-1114111]", sut.ToIString());
        }

        [TestMethod]
        public void NotRangeShouldMatch()
        {
            var sut = Codepoints.From('u', 'w').Not();

            Assert.IsFalse(sut.Contains('u'));
            Assert.IsFalse(sut.Contains('v'));
            Assert.IsFalse(sut.Contains('w'));
        }

        [TestMethod]
        public void NotRangeShouldntMatch()
        {
            var sut = Codepoints.From('u', 'w').Not();

            Assert.IsTrue(sut.Contains('a'));
            Assert.IsTrue(sut.Contains('z'));
        }
    }
}