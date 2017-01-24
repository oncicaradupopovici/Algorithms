using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BitManipulation.Test
{
    public class BitManipulationTests
    {
        [Theory]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(8, true)]
        public void Test_IsPowerOfTwo(int x, bool expected)
        {
            //Arrange
            var alg = new BitManipulation.Algorithm();

            //Act
            var actual = alg.IsPowerOfTwo(x);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
