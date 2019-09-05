using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class TransformTests
    {
        [TestMethod]
        public void TransformShouldCreateDfa()
        {
            var state1 = new State();
            var state2 = new State();
            var state3 = new State();

            state1.Add(Codepoints.From('1'), state2);
            state2.Add(Codepoints.From('2'), state3);
            state3.Add(Codepoints.From('3'), state1);

            var nfa = FA.From(state1, state3);

            var dfa = nfa.ToDfa().Minimize();

            Assert.IsNotNull(dfa);
            Assert.AreEqual(3, dfa.States.Count);
        }
    }
}
