using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingu.Automata.Tests
{
    [TestClass]
    public class NfaClosureTests
    {
        [TestMethod]
        public void NfaClosureShouldNewWithEmptyStates()
        {
            var state = new State();

            var sut = new Closure(Enumerable.Empty<State>(), state);

            Assert.IsNotNull(sut);
            Assert.IsNotNull(sut.Set);
            Assert.AreEqual(0, sut.Set.Count);
            Assert.IsNotNull(sut.DfaState);
            Assert.AreEqual(false, sut.DfaState.IsFinal);
        }

        [TestMethod]
        public void NfaClosureShouldNewWithOneState()
        {
            var state = new State();

            var sut = new Closure(Enumerable.Repeat(state, 1), state);

            Assert.IsNotNull(sut);
            Assert.IsNotNull(sut.Set);
            Assert.AreEqual(1, sut.Set.Count);
            Assert.IsNotNull(sut.DfaState);
            Assert.AreEqual(true, sut.DfaState.IsFinal);
        }

        [TestMethod]
        public void NfaClosureShouldNewWithTwoStates()
        {
            var state1 = new State();
            var state2 = new State();

            var sut = new Closure(new [] { state1, state2 }, state1);

            Assert.IsNotNull(sut);
            Assert.IsNotNull(sut.Set);
            Assert.AreEqual(2, sut.Set.Count);
            Assert.IsNotNull(sut.DfaState);
            Assert.AreEqual(true, sut.DfaState.IsFinal);
        }


        [TestMethod]
        public void NfaClosuresFromSameSetShouldBeEqual()
        {
            var state1 = new State();
            var state2 = new State();

            var sut1 = new Closure(new[] { state1, state2 }, state1);
            var sut2 = new Closure(new[] { state2, state1 }, state1);

            Assert.IsTrue(sut1.Equals(sut2));
            Assert.AreEqual(sut1.GetHashCode(), sut1.GetHashCode());
        }
    }
}
