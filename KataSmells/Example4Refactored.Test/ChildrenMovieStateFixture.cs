using FluentAssertions;
using NUnit.Framework;

namespace KataSmells.Example4Refactored.Test
{
    [TestFixture]
    public class ChildrenMovieStateFixture
    {
        private ChildrenMovieState _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new ChildrenMovieState();
        }

        [Test]
        public void GetCharge_WithDaysRentedSmaller3_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 2;
            var result = _testee.GetCharge(daysRented);

            // Assert
            const double expectedResult = 1.5;
            result.Should().Be(expectedResult);
        }

        [Test]
        public void GetCharge_WithDaysRentedHigher3_ReturnsExpectedResult()
        {
            // Act
            const int daysRented = 4;
            var result = _testee.GetCharge(daysRented);

            // Assert
            const double expectedResult = 3;
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