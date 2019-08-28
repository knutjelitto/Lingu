using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mean.Language.Tests
{
    [TestClass]
    public class PackageTests
    {
        [TestMethod]
        public void EmptyPackage()
        {
            var text = @"
                package core
                {
                }";

            Assert.AreEqual("package core { }", Checker.Package(text));
        }
    }
}
