using System;
using ComputerNetworkGraph;
using Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MockRepoTests
    {
        [TestMethod]
        public void TestMockRepoDisconnected()
        {
            ICompPairsRepo repo = new MockCompPairsRepoDisconnected();

            var graph = ComputerGraphFactory.GetGraph(repo);
            Assert.IsFalse(graph.IsConnected);
        }

        [TestMethod]
        public void TestMockRepoConnected()
        {
            ICompPairsRepo repo = new MockCompPairsRepoConnected();

            var graph = ComputerGraphFactory.GetGraph(repo);
            Assert.IsTrue(graph.IsConnected);
        }
    }
}
