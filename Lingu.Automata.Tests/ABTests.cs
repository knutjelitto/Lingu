using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class ABTests
    {
        [TestMethod]
        public void ThereShouldBeFourDfaStates()
        {
            // [ab]?[abc][ab]?
            var matcher = MakeMatcher();

            Assert.AreEqual(4, matcher.FA.States.Count);
        }

        [TestMethod]
        public void CheckLength2()
        {
            var matcher = MakeMatcher();

            foreach (var lexeme in AllThatMustMatch(2))
            {
                Assert.IsTrue(matcher.FullMatch(lexeme), $"can't match '{lexeme}'");
            }
        }

        [TestMethod]
        public void CheckLength3()
        {
            var matcher = MakeMatcher();

            foreach (var lexeme in AllThatMustMatch(3))
            {
                Assert.IsTrue(matcher.FullMatch(lexeme), $"can't match '{lexeme}'");
            }
        }

        [TestMethod]
        public void CheckMisMatches()
        {
        }

        private static IEnumerable<string> AllThatMustMatch(int length)
        {
            foreach (var one in "ab")
            {
                if (length == 1)
                {
                    yield return one.ToString();
                }
                else
                {
                    foreach (var two in "abc")
                    {
                        if (length == 2)
                        {
                            yield return one.ToString() + two;

                        }
                        else
                        {
                            foreach (var three in "ab")
                            {
                                yield return one.ToString() + two + three;
                            }
                        }
                    }
                }
            }
        }

        private static Matcher MakeMatcher()
        {
            // [ab]?[abc][ab]?
            var first = new State();
            var center = new State();
            var last = new State();
            var end = new State();

            var ab = Integers.From('a', 'b');
            var ac = Integers.From('a', 'c');

            first.Add(ab, center);
            first.Add(center);
            center.Add(ac, last);
            last.Add(ab, end);
            last.Add(end);

            var nfa = FA.From(first, end);

            return new Matcher(nfa.ToDfa().Minimize());
        }
    }
}
