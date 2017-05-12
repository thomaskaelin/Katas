using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace KataSmells.Example4Refactored.Test
{
    [TestFixture]
    public class MovieFixture
    {
        private Movie _testee;
        private IMovieState _fakeMovieState;

        [SetUp]
        public void SetUp()
        {
            const string title = "Title";
            _fakeMovieState = A.Fake<IMovieState>();
            _testee = new Movie(title, _fakeMovieState);
        }

        [Test]
        public void Constructor_Initializes_PropertyTitle()
        {
            // Assert
            const string expectedTitle = "Title";
            _testee.Title.Should().Be(expectedTitle);
        }

        [Test]
        public void GetCharge_CallsGetCharge_OnMovieState()
        {
            // Act
            const int daysRented = 2;
            _testee.GetCharge(daysRented);

            // Assert
            A.CallTo(() => _fakeMovieState.GetCharge(daysRented)).MustHaveHappened();
        }

        [Test]
        public void GetExtraFrequentRenterPoints_CallsGetExtraFrequentRenterPoints_OnMovieState()
        {
            // Act
            const int daysRented = 2;
            _testee.GetExtraFrequentRenterPoints(daysRented);

            // Assert
            A.CallTo(() => _fakeMovieState.GetExtraFrequentRenterPoints(daysRented)).MustHaveHappened();
        }
    }
}