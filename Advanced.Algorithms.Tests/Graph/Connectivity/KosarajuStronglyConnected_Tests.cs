﻿using Advanced.Algorithms.DataStructures.Graph.AdjacencyList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Advanced.Algorithms.Graph.Connectivity;

namespace Advanced.Algorithms.Tests.Graph.Connectivity
{

    [TestClass]
    public class KosarajuStronglyConnected_Tests
    {

        [TestMethod]
        public void KosarajuStronglyConnected_Smoke_Test()
        {
            var graph = new DiGraph<char>();

            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('E');
            graph.AddVertex('F');
            graph.AddVertex('G');
            graph.AddVertex('H');


            graph.AddEdge('A', 'B');
            graph.AddEdge('B', 'C');
            graph.AddEdge('C', 'A');

            graph.AddEdge('C', 'D');
            graph.AddEdge('D', 'E');

            graph.AddEdge('E', 'F');
            graph.AddEdge('F', 'G');
            graph.AddEdge('G', 'E');

            graph.AddEdge('F', 'H');

            var algo = new KosarajuStronglyConnected<char>();

            var result = algo.FindStronglyConnectedComponents(graph);

            Assert.AreEqual(4, result.Count);

            var expectedResult = new List<List<char>>() {
                    new char[] { 'A', 'B', 'C' }.ToList(),
                    new char[] { 'D' }.ToList(),
                    new char[] { 'E', 'F', 'G' }.ToList(),
                    new char[] { 'H' }.ToList()
            };

            for (int i = 0; i < expectedResult.Count; i++)
            {
                var expectation = expectedResult[i];
                var actual = result[i];

                Assert.IsTrue(expectation.Count == actual.Count);

                foreach (var vertex in expectation)
                {
                    Assert.IsTrue(actual.Contains(vertex));
                }

            }
        }
    }
}