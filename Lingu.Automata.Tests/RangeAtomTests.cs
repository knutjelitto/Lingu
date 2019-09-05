using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class RangeAtomTests
    {
        [TestMethod]
        public void RangeCreateString()
        {
            var sut = Codepoints.From('u', 'w');

            Assert.AreEqual("['u'-'w']", sut.ToString());
        }

        [TestMethod]
        public void RangeShouldMatch()
        {
            var sut = Codepoints.From('u', 'w');

            Assert.IsTrue(sut.Contains('u'));
            Assert.IsTrue(sut.Contains('v'));
            Assert.IsTrue(sut.Contains('w'));
        }

        [TestMethod]
        public void RangeShouldntMatch()
        {
            var sut = Codepoints.From('u', 'w');

            Assert.IsFalse(sut.Contains('a'));
            Assert.IsFalse(sut.Contains('z'));
        }
    }
}