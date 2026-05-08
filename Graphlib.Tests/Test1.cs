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
        public void BFS_SimpleLinearGraph_ReturnsCorrectOrder()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");
            var result = GraphAlgorithms.BFS(_graph, "A");
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("A", result[0]);
        }

        [TestMethod]
        public void BFS_StarGraph_VisitsAllNeighbors()
        {
            _graph.AddEdge("Center", "Leaf1");
            _graph.AddEdge("Center", "Leaf2");
            _graph.AddEdge("Center", "Leaf3");
            var result = GraphAlgorithms.BFS(_graph, "Center");
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.Contains("Leaf1"));
        }

        [TestMethod]
        public void DFS_DeepGraph_GoesDepthFirst()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");
            _graph.AddEdge("C", "D");
            _graph.AddEdge("A", "E"); // E - сосед A, но DFS уйдет в B->C->D сначала
            var result = GraphAlgorithms.DFS(_graph, "A");
            Assert.AreEqual("A", result[0]);
            Assert.AreEqual("B", result[1]);
            Assert.AreEqual("C", result[2]);
            Assert.AreEqual("D", result[3]);
        }

        [TestMethod]
        public void BFS_DisconnectedGraph_VisitsOnlyComponent()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("C", "D");
            var result = GraphAlgorithms.BFS(_graph, "A");
            Assert.AreEqual(2, result.Count);
            Assert.IsFalse(result.Contains("C"));
        }

        [TestMethod]
        public void BFS_StartVertexNotExists_ReturnsEmptyList()
        {
            _graph.AddEdge("A", "B");
            var result = GraphAlgorithms.BFS(_graph, "Z");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void IsReachable_DirectConnection_ReturnsTrue()
        {
            _graph.AddEdge("A", "B");
            Assert.IsTrue(GraphAlgorithms.IsReachable(_graph, "A", "B"));
        }

        [TestMethod]
        public void IsReachable_IndirectConnection_ReturnsTrue()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");
            Assert.IsTrue(GraphAlgorithms.IsReachable(_graph, "A", "C"));
        }

        [TestMethod]
        public void IsReachable_NoPath_ReturnsFalse()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("C", "D");
            Assert.IsFalse(GraphAlgorithms.IsReachable(_graph, "A", "D"));
        }

        [TestMethod]
        public void IsReachable_SelfReachable_ReturnsTrue()
        {
            _graph.AddEdge("A", "B");
            Assert.IsTrue(GraphAlgorithms.IsReachable(_graph, "A", "A"));
        }

        [TestMethod]
        public void FindConnectedComponents_EmptyGraph_ReturnsEmptyList()
        {
            var components = GraphAlgorithms.FindConnectedComponents(_graph);
            Assert.AreEqual(0, components.Count);
        }

        [TestMethod]
        public void FindConnectedComponents_SingleVertex_ReturnsOneComponent()
        {
            _graph.AddVertex("A"); // Добавляем изолированную вершину
            var components = GraphAlgorithms.FindConnectedComponents(_graph);
            Assert.AreEqual(1, components.Count);
            Assert.AreEqual(1, components[0].Count);
        }

        [TestMethod]
        public void FindConnectedComponents_MultipleIsolatedVertices_ReturnsMultipleComponents()
        {
            _graph.AddVertex("A");
            _graph.AddVertex("B");
            _graph.AddVertex("C");
            var components = GraphAlgorithms.FindConnectedComponents(_graph);
            Assert.AreEqual(3, components.Count);
        }

        [TestMethod]
        public void FindConnectedComponents_TwoClusters_ReturnsTwoLists()
        {
            _graph.AddEdge("A", "B");
            _graph.AddEdge("C", "D");
            var components = GraphAlgorithms.FindConnectedComponents(_graph);
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void Dijkstra_SimplePath_CorrectDistance()
        {
            _graph.AddEdge("A", "B", 5);
            _graph.AddEdge("B", "C", 3);
            var distances = GraphAlgorithms.Dijkstra(_graph, "A");
            Assert.AreEqual(8, distances["C"]);
        }

        [TestMethod]
        public void Dijkstra_ShorterPathViaIntermediate_Chosen()
        {
            _graph.AddEdge("A", "C", 10);
            _graph.AddEdge("A", "B", 2);
            _graph.AddEdge("B", "C", 2);
            var distances = GraphAlgorithms.Dijkstra(_graph, "A");
            Assert.AreEqual(4, distances["C"]); // A->B->C дешевле, чем A->C
        }

        [TestMethod]
        public void Dijkstra_UnreachableVertex_ReturnsMaxValue()
        {
            _graph.AddEdge("A", "B", 1);
            _graph.AddEdge("C", "D", 1);
            var distances = GraphAlgorithms.Dijkstra(_graph, "A");
            Assert.AreEqual(int.MaxValue, distances["D"]);
        }

        [TestMethod]
        public void Dijkstra_PathReconstruction_CorrectSequence()
        {
            _graph.AddEdge("A", "B", 1);
            _graph.AddEdge("B", "C", 1);
            _graph.AddEdge("C", "D", 1);
            var path = GraphAlgorithms.GetDijkstraPath(_graph, "A", "D");
            Assert.AreEqual(4, path.Count);
            Assert.AreEqual("A", path[0]);
            Assert.AreEqual("D", path[3]);
        }

        [TestMethod]
        public void FindArticulationPoints_BridgeGraph_EndpointsAreArticulation()
        {
            // A - B - C. B - точка сочленения.
            _graph.AddEdge("A", "B");
            _graph.AddEdge("B", "C");
            var points = GraphAlgorithms.FindArticulationPoints(_graph);
            Assert.IsTrue(points.Contains("B"));
            Assert.AreEqual(1, points.Count);
        }

        [TestMethod]
        public void FindArticulationPoints_StarGraph_CenterIsArticulation()
        {
            _graph.AddEdge("Center", "Leaf1");
            _graph.AddEdge("Center", "Leaf2");
            var points = GraphAlgorithms.FindArticulationPoints(_graph);
            Assert.IsTrue(points.Contains("Center"));
        }

        [TestMethod]
        public void FindMST_Prim_CalculatesCorrectWeight()
        {
            _graph.AddEdge("A", "B", 1);
            _graph.AddEdge("B", "C", 2);
            _graph.AddEdge("A", "C", 10);
            var mst = GraphAlgorithms.FindMST_Prim(_graph, "A");
            int totalWeight = mst.Sum(e => e.Weight);
            Assert.AreEqual(3, totalWeight);
        }
    }
}