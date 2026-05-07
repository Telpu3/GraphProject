using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphlib;
using System.Collections.Generic;
using System.Linq;

namespace Graphlib.Tests
{
    [TestClass]
    public class GraphAlgorithmTests
    {
        private Graph _graph;

        [TestInitialize]
        public void Setup()
        {
            _graph = new Graph();
        }

        [TestMethod]
        public void BFS_SimpleGraph_ReturnsCorrectOrder()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");

            var result = GraphAlgorithms.BFS(_graph, "A");

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("A", result[0]);
            Assert.AreEqual("B", result[1]);
            Assert.AreEqual("C", result[2]);
        }

        [TestMethod]
        public void DFS_SimpleGraph_ReturnsCorrectOrder()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");

            var result = GraphAlgorithms.DFS(_graph, "A");

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("A", result[0]);
            Assert.AreEqual("B", result[1]);
            Assert.AreEqual("C", result[2]);
        }

        [TestMethod]
        public void BFS_StartVertexNotExists_ReturnsEmptyList()
        {
            _graph.AddEdge("A", "B");

            var result = GraphAlgorithms.BFS(_graph, "Z");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void IsReachable_ConnectedVertices_ReturnsTrue()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");

            Assert.IsTrue(GraphAlgorithms.IsReachable(_graph, "A", "C"));
            Assert.IsTrue(GraphAlgorithms.IsReachable(_graph, "C", "A")); // Неориентированный
        }

        [TestMethod]
        public void IsReachable_DisconnectedVertices_ReturnsFalse()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("C", "D");

            Assert.IsFalse(GraphAlgorithms.IsReachable(_graph, "A", "C"));
        }

        [TestMethod]
        public void FindConnectedComponents_TwoComponents_ReturnsTwoLists()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("C", "D");

            var components = GraphAlgorithms.FindConnectedComponents(_graph);
            Assert.AreEqual(2, components.Count);

            bool foundComp1 = components.Any(c => c.Contains("A") && c.Contains("B"));
            bool foundComp2 = components.Any(c => c.Contains("C") && c.Contains("D"));

            Assert.IsTrue(foundComp1);
            Assert.IsTrue(foundComp2);
        }

        [TestMethod]
        public void FindConnectedComponents_FullyConnected_ReturnsOneList()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");
            _graph.AddEdge("C", "A");
            var components = GraphAlgorithms.FindConnectedComponents(_graph);

            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(3, components[0].Count);
        }

        [TestMethod]
        public void FindConnectedComponents_EmptyGraph_ReturnsEmptyList()
        {
            var components = GraphAlgorithms.FindConnectedComponents(_graph);
            Assert.AreEqual(0, components.Count);
        }
    }
}