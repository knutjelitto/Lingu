using Lingu.Runtime.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Lingu.Runtime.Tests
{
    [TestClass]
    public class SourceTests
    {
        [TestMethod]
        public void NumberOfLines()
        {
            var target = MakeSource();

            Assert.AreEqual(9, target.LineCount);
        }

        [TestMethod]
        public void GetLineByLineNo()
        {
            var target = MakeSource();

            Assert.AreEqual(loremIpsums[0], target.GetLine(1).ToString());
            Assert.AreEqual(loremIpsums[1], target.GetLine(2).ToString());
            Assert.AreEqual(loremIpsums[2], target.GetLine(3).ToString());
            Assert.AreEqual(loremIpsums[3], target.GetLine(4).ToString());
            Assert.AreEqual(loremIpsums[4], target.GetLine(5).ToString());
            Assert.AreEqual(loremIpsums[5], target.GetLine(6).ToString());
            Assert.AreEqual(loremIpsums[6], target.GetLine(7).ToString());
            Assert.AreEqual(loremIpsums[7], target.GetLine(8).ToString());
            Assert.AreEqual(loremIpsums[8], target.GetLine(9).ToString());
        }

        [TestMethod]
        public void GetLineNoByIndex()
        {
            var target = MakeSource();

            Assert.AreEqual(1, target.GetLineNoFromIndex(0));
            Assert.AreEqual(2, target.GetLineNoFromIndex(2));
            Assert.AreEqual(2, target.GetLineNoFromIndex(3));
            Assert.AreEqual(2, target.GetLineNoFromIndex(2 + loremIpsums[1].Length + 0)); // \r
            Assert.AreEqual(2, target.GetLineNoFromIndex(2 + loremIpsums[1].Length + 1)); // \n
            Assert.AreEqual(3, target.GetLineNoFromIndex(2 + loremIpsums[1].Length + 2)); // 'i'

            var last = loremIpsums.Select(l => l.Length).Sum() + 2 * (loremIpsums.Length);

            Assert.AreEqual(9, target.GetLineNoFromIndex(last));
            Assert.AreEqual(9, target.GetLineNoFromIndex(last + 100));
        }

        [TestMethod]
        public void TestsShouldMatch()
        {
            var target = MakeSource();

            var expected = string.Join(string.Empty, loremIpsums);
            var actual = string.Join(string.Empty, target.GetLines());

            Assert.AreEqual(expected, actual);
        }

        private Source MakeSource()
        {
            var loremIpsum = string.Join(Environment.NewLine, loremIpsums);
            return Source.FromString(loremIpsum);
        }

        private static readonly string[] loremIpsums =
        {
            "",
            "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor",
            "invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam",
            "et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est",
            "Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed",
            "diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.",
            "At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea",
            "takimata sanctus est Lorem ipsum dolor sit amet.",
            ""
        };
    }
}
