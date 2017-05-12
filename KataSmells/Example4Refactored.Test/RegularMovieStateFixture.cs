using FluentAssertions;
using NUnit.Framework;

namespace KataSmells.Example4Refactored.Test
{
    [TestFixture]
    public class RegularMovieStateFixture
    {
        private RegularMovieState _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new RegularMovieState();
        }

        [Test]
        public void GetCharge_WithDaysRentedSmaller2_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 1;
            var result = _testee.GetCharge(daysRented);

            // Assert
            const int expectedResult = 2;
            result.Should().Be(expectedResult);
        }

        [Test]
        public void GetCharge_WithDaysRentedHigher2_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 3;
            var result = _testee.GetCharge(daysRented);

            // Assert
            const double expectedResult = 3.5;
            result.Should().Be(expectedResult);
        }

        [Test]
        public void GetExtraFrequentRenterPoints_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 1;
            var result = _testee.GetExtraFrequentRenterPoints(daysRented);

            // Assert
            const int expectedResult = 0;
            result.Should().Be(expectedResult);
        }
    }
}