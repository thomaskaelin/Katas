using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KataSmells.Example4Refactored.Test
{
    [TestFixture]
    public class RentralFixture
    {
        private Rental _testee;
        private IMovie _fakeMovie;

        [SetUp]
        public void SetUp()
        {
            _fakeMovie = A.Fake<IMovie>();
            const int daysRented = 2;
            _testee = new Rental(_fakeMovie, daysRented);
        }

        [Test]
        public void Constructor_Initializes_PropertyMovie()
        {
            // Assert
            _testee.Movie.Should().NotBeNull();
        }

        public void Constructor_Initializes_PropertyDaysRented()
        {
            // Assert
            const int expectedDaysRented = 2;
            _testee.DaysRented.Should().Be(expectedDaysRented);
        }

        public void GetAmountForRental_CallsGetCharge_OnMovie()
        {
            // Act
            _testee.GetAmountForRental();

            // Assert
            const int daysRented = 2;
            A.CallTo(() => _fakeMovie.GetCharge(daysRented)).MustHaveHappened();
        }

        [Test]
        public void GetFrequentRenterPoints_CallsGetExtraFrequentRenterPoints_OnMovie()
        {
            // Act
            _testee.GetFrequentRenterPoints();

            // Assert
            const int daysRented = 2;
            A.CallTo(() => _fakeMovie.GetExtraFrequentRenterPoints(daysRented)).MustHaveHappened();
        }

        [Test]
        public void GetRequentRenterPoints_Returns_ExpectedResult()
        {
            // Arrange
            const int daysRented = 2;
            A.CallTo(() => _fakeMovie.GetExtraFrequentRenterPoints(daysRented)).Returns(daysRented);
            // Act
            var result = _testee.GetFrequentRenterPoints();

            // Assert
            const int expectedResult = 3;
            result.Should().Be(expectedResult);
        }

    }
}