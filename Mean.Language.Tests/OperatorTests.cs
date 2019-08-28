using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mean.Language.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void Equality()
        {
            Assert.AreEqual("(1 == 2)", Checker.Check("1==2", Parser.Expression));
            Assert.AreEqual("(a == 2)", Checker.Check("a==2", Parser.Expression));
            Assert.AreEqual("(1 == b)", Checker.Check("1==b", Parser.Expression));
        }

        [TestMethod]
        public void NotEquality()
        {
            Assert.AreEqual("(1 != 2)", Checker.Check("1!=2", Parser.Expression));
            Assert.AreEqual("(a != 2)", Checker.Check("a!=2", Parser.Expression));
            Assert.AreEqual("(1 != b)", Checker.Check("1!=b", Parser.Expression));
        }
    }
}
