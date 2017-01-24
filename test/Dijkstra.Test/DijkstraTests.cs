using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Dijkstra.Test
{
    public class DijkstraTests
    {
        [Fact]
        public void Throws_When_Source_OrTarget_NotFound()
        {
            //Arrange
            var graph = new Dijkstra.Graph();
            graph.AddNeighbours("Onesti", "Bacau", 50);
            var sut = new Dijkstra.Algorithm();

            //Act
            Action action1 = () => { sut.FindMinDistance(graph, "Bucuresti", "Bacau"); };
            Action action2 = () => { sut.FindMinDistance(graph, "Onesti", "Bucuresti"); };

            //Assert
            Assert.Throws<KeyNotFoundException>(action1);
            Assert.Throws<KeyNotFoundException>(action2);
        }

        [Fact]
        public void Returns_Null_For_Not_Existent_Path()
        {
            //Arrange
            var graph = new Dijkstra.Graph();
            graph.AddNeighbours("Onesti", "Bacau", 50);
            graph.AddNeighbours("Bucuresti", "Urziceni", 50);
            var sut = new Dijkstra.Algorithm();

            //Act
            var actual = sut.FindMinDistance(graph, "Onesti", "Bucuresti");

            //Assert
            Assert.Null(actual);
        }

        [Fact]
        public void Returns_Zero_For_Equal_Source_And_Target()
        {
            //Arrange
            var graph = new Dijkstra.Graph();
            graph.AddNeighbours("Onesti", "Bacau", 50);
            var sut = new Dijkstra.Algorithm();

            //Act
            var actual = sut.FindMinDistance(graph, "Onesti", "Onesti");

            //Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Returns_Minimum_Distance()
        {
            //Arrange
            var graph = new Dijkstra.Graph();
            graph.AddNeighbours("Onesti", "Bacau", 50);
            graph.AddNeighbours("Onesti", "Adjud", 40);
            graph.AddNeighbours("Bacau", "Adjud", 60);
            graph.AddNeighbours("Bacau", "Roman", 40);
            graph.AddNeighbours("Bacau", "Piatra Neamt", 60);
            graph.AddNeighbours("Roman", "Falticeni", 80);
            graph.AddNeighbours("Piatra Neamt", "Falticeni", 80);
            graph.AddNeighbours("Falticeni", "Suceava", 30);
            var sut = new Dijkstra.Algorithm();

            //Act
            var actualOnestiSuceava = sut.FindMinDistance(graph, "Onesti", "Suceava");

            //Assert
            Assert.Equal(200, actualOnestiSuceava);
        }
    }
}
