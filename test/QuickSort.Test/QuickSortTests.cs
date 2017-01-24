using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace QuickSort.Test
{
    public class QuickSortTests
    {
        [Theory]
        [InlineData(new[] { 5, 10, 45, 12, 1, 56, 25, 83, 98, 78, 35 })]
        public void SampleTests(int[] input)
        {
            //Arrange
            var sut = new QuickSort.Algorithm<int>();

            //Act           
            sut.QuickSort(input);

            //Assert
            var expected = input.ToList();
            expected.Sort();

            Assert.Equal(expected, input);
        }
    }
}
