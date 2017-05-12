using FluentAssertions;
using NUnit.Framework;

namespace KataSmells.Example4Refactored.Test
{
    [TestFixture]
    public class NewReleayseMovieStateFixture
    {
        private NewReleaseMovieState _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new NewReleaseMovieState();
        }

        [Test]
        public void GetCharge_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 2;
            var result = _testee.GetCharge(daysRented);

            // Assert
            const int expectedResult = 6;
            result.Should().Be(expectedResult);
        }

        [Test]
        public void GetExtraFrequentRenterPoints_WithDaysRentedSmallerOne_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 0;
            var result = _testee.GetExtraFrequentRenterPoints(daysRented);

            // Assert
            const int expectedResult = 0;
            result.Should().Be(expectedResult);
        }

        public void GetExtraFrequentRenterPoints_WithDaysRentedHigherOne_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 2;
            var result = _testee.GetExtraFrequentRenterPoints(daysRented);

            // Assert
            const int expectedResult = 1;
            result.Should().Be(expectedResult);
        }

    }
}