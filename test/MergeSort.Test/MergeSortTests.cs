using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MergeSort.Test
{
    public class MergeSortTests
    {
        [Theory]
        [InlineData(new[] { 3, 8, 2, 9, 6, 1, 7 })]
        [InlineData(new[] { 5, 10, 45, 12, 1, 56, 25, 83, 98, 78, 35 })]
        public void SampleTests(int[] input)
        {
            //Arrange
            var sut = new MergeSort.Algorithm<int>();

            //Act
            var actual = sut.MergeSort(input);

            //Assert
            var expected = input.ToList();
            expected.Sort();
            Assert.Equal(expected, actual);
        }
    }
}
