using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GraphTraversal.Test
{
    public class GraphTraversalTests
    {
        [Fact]
        public void Test_DFS()
        {
            //Arrange
            var root = GetRootNode();
            var sut = new GraphTraversal.Algorithm<int>();

            //Act
            var actual = sut.DfsTraverse(root).Select(n => n.Value);

            //Assert
            var expected = new List<int> { 1, 2, 3, 4, };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_BFS()
        {
            //Arrange
            var root = GetRootNode();
            var sut = new GraphTraversal.Algorithm<int>();

            //Act
            var actual = sut.BfsTraverse(root).Select(n => n.Value);

            //Assert
            var expected = new List<int> { 1, 2, 4, 3, };
            Assert.Equal(expected, actual);
        }

        private GraphNode<int> GetRootNode()
        {
            var first = new GraphNode<int>(1);
            var second = new GraphNode<int>(2);
            var third = new GraphNode<int>(3);
            var fourth = new GraphNode<int>(4);

            first.AdjNodes.AddRange(new List<GraphNode<int>> { second, fourth });
            second.AdjNodes.AddRange(new List<GraphNode<int>> { first, third });
            third.AdjNodes.AddRange(new List<GraphNode<int>> { first, fourth });

            return first;
        }
    }
}
