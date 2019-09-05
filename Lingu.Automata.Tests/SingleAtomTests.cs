using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class SingleAtomTests
    {
        [TestMethod]
        public void SingleCreateString()
        {
            var sut = Codepoints.From('a');

            Assert.AreEqual("['a']", sut.ToString());
        }

        [TestMethod]
        public void SingleShouldMatch()
        {
            var sut = Codepoints.From('a');

            Assert.IsTrue(sut.Contains('a'));
        }

        [TestMethod]
        public void SingleShouldntMatch()
        {
            var sut = Codepoints.From('a');

            Assert.IsFalse(sut.Contains('b'));
        }
    }
}