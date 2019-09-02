using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Commons.Tests
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void HashShouldHashDifferentForRandomOrder()
        {
            var o1 = 11;
            var o2 = 12;
            var o3 = 13;

            var s1 = new[] { o1, o2, o3 };
            var s2 = new[] { o1, o3, o2 };
            var s3 = new[] { o2, o1, o3 };
            var s4 = new[] { o2, o3, o1 };
            var s5 = new[] { o3, o1, o2 };
            var s6 = new[] { o3, o2, o1 };

            Assert.AreNotEqual(s1.Hash(), s2.Hash());
            Assert.AreNotEqual(s1.Hash(), s3.Hash());
            Assert.AreNotEqual(s1.Hash(), s4.Hash());
            Assert.AreNotEqual(s1.Hash(), s5.Hash());
            Assert.AreNotEqual(s1.Hash(), s6.Hash());

            Assert.AreNotEqual(s2.Hash(), s3.Hash());
            Assert.AreNotEqual(s2.Hash(), s4.Hash());
            Assert.AreNotEqual(s2.Hash(), s5.Hash());
            Assert.AreNotEqual(s2.Hash(), s6.Hash());

            Assert.AreNotEqual(s3.Hash(), s4.Hash());
            Assert.AreNotEqual(s3.Hash(), s5.Hash());
            Assert.AreNotEqual(s3.Hash(), s6.Hash());

            Assert.AreNotEqual(s4.Hash(), s5.Hash());
            Assert.AreNotEqual(s4.Hash(), s6.Hash());

            Assert.AreNotEqual(s5.Hash(), s6.Hash());
        }
    }
}
