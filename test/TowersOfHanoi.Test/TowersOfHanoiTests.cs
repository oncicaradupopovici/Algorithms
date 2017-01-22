using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TowersOfHanoi.Test
{
    public class TowersOfHanoiTests
    {
        [Theory]
        [InlineData(3, TowerName.A, TowerName.B)]
        public void SampleTests(int n, TowerName from, TowerName to)
        {
            //Arrange
            var sut = new TowersOfHanoi.Algorithm();

            //Act
            var actual = sut.SolveHanoi(n, from, to);

            //Assert
            var expectedMovesCount = Math.Pow(2, n) - 1;
            Assert.Equal(expectedMovesCount, actual.Count());
        }
    }
}
