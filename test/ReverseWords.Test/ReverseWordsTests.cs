using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ReverseWords.Test
{
    public class ReverseWordsTests
    {
        [Fact]
        public void ReverseWordsThrowsArgumentNullExceptionForNullInput()
        {
            var sut = new ReverseWords.Algorithm();

            Action act = () => sut.ReverseWords(null);

            Assert.Throws<ArgumentNullException>("words", act);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("Ending with space ", "gnidnE htiw ecaps ")]
        [InlineData(" Starting with space", " gnitratS htiw ecaps")]
        [InlineData("Contains  two  spaces", "sniatnoC  owt  secaps")]
        [InlineData("Contains_no_spaces", "secaps_on_sniatnoC")]
        [InlineData("Cat and dog", "taC dna god")]
        public void ReverseWordsWorks(string input, string expected)
        {
            var sut = new ReverseWords.Algorithm();

            var actual = sut.ReverseWords(input);

            Assert.Equal(expected, actual);
        }
    }
}
