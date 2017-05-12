using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace KataSmells.Example4Refactored.Test
{
    public class Example4RefactoredFixture
    {
        private Customer _testee;
        private const string Name = "NewName";

        [SetUp]
        public void SetUp()
        {
            _testee = new Customer(Name);
        }
        
        [Test]
        public void Property_Name_Initializes_WithExpectedName()
        {
            // Assert
            _testee.Name.Should().Be(Name);
        }

        [Test]
        public void Statement_WithPriceCodeRegular_ReturnsExpectedResult()
        {
            // Arrange
            AddRegularState(2);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t2\r\nAmount owed is 2\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeRegularAndDaysRentedHigherThanTwo_ReturnsExpectedResult()
        {
            // Arrange
            AddRegularState(3);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t3.5\r\nAmount owed is 3.5\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeNewReleaseAndOneRentalDay_ReturnsExpectedResult()
        {
            // Arrange
            AddNewReleaseState(1);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t3\r\nAmount owed is 3\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeNewReleaseAndTwoRentalDays_ReturnsExpectedResult()
        {
            // Arrange
            AddNewReleaseState(2);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t6\r\nAmount owed is 6\r\nYou earned 2 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeChildren_ReturnsExpectedResult()
        {
            // Arrange
            AddChildrenRental(2);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t1.5\r\nAmount owed is 1.5\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeChildrenAndDaysRentedHigherThanThree_ReturnsExpectedResult()
        {
            // Arrange
            AddChildrenRental(4);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t3\r\nAmount owed is 3\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithTwoRentals_ReturnsExpectedResult()
        {
            // Arrange
            AddNewReleaseState(2);
            AddRegularState(1);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n	Titel	6\r\n	Titel	2\r\nAmount owed is 8\r\nYou earned 3 frequent renter points");
        }

        private void AddRental(IMovieState movieState, int daysRented)
        {
            // toDo use fakes
            /*var fakeMovie = A.Fake<IMovie>();
            A.CallTo(() => fakeMovie.Title).Returns("Titel");
            A.CallTo(() => fakeMovie.PriceCode).Returns(priceCode);*/
            /*var fakeRental = A.Fake<IRental>();
            A.CallTo(() => fakeRental.Movie).Returns(fakeMovie);
            A.CallTo(() => fakeRental.DaysRented).Returns(daysRented);*/
            var movie = new Movie("Titel", movieState);
            var rental = new Rental(movie, daysRented);
            _testee.AddRental(rental);
        }

        private void AddChildrenRental(int daysRented)
        {
            var childrenState = new ChildrenMovieState();
            AddRental(childrenState, daysRented);
        }

        private void AddNewReleaseState(int daysRented)
        {
            var newReleaseState = new NewReleaseMovieState();
            AddRental(newReleaseState, daysRented);
        }

        private void AddRegularState(int daysRented)
        {
            var regularState = new RegularMovieState();
            AddRental(regularState, daysRented);
        }
    }
}