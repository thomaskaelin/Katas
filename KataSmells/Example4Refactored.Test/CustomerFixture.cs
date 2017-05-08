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
            AddRental(Movie.REGULAR, 2);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t2\r\nAmount owed is 2\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeRegularAndDaysRentedHigherThanTwo_ReturnsExpectedResult()
        {
            // Arrange
            AddRental(Movie.REGULAR, 3);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t3.5\r\nAmount owed is 3.5\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeNewReleaseAndOneRentalDay_ReturnsExpectedResult()
        {
            // Arrange
            AddRental(Movie.NEW_RELEASE, 1);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t3\r\nAmount owed is 3\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeNewReleaseAndTwoRentalDays_ReturnsExpectedResult()
        {
            // Arrange
            AddRental(Movie.NEW_RELEASE, 2);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t6\r\nAmount owed is 6\r\nYou earned 2 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeChildren_ReturnsExpectedResult()
        {
            // Arrange
            AddRental(Movie.CHILDREN, 2);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t1.5\r\nAmount owed is 1.5\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithPriceCodeChildrenAndDaysRentedHigherThanThree_ReturnsExpectedResult()
        {
            // Arrange
            AddRental(Movie.CHILDREN, 4);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n\tTitel\t3\r\nAmount owed is 3\r\nYou earned 1 frequent renter points");
        }

        [Test]
        public void Statement_WithTwoRentals_ReturnsExpectedResult()
        {
            // Arrange
            AddRental(Movie.NEW_RELEASE, 2);
            AddRental(Movie.REGULAR, 1);

            // Act
            var result = _testee.Statement();

            // Assert
            result.Should().Be("Rental record for NewName\r\n	Titel	6\r\n	Titel	2\r\nAmount owed is 8\r\nYou earned 3 frequent renter points");
        }

        private void AddRental(int priceCode, int daysRented)
        {
            // toDo use fakes
            var fakeMovie = A.Fake<IMovie>();
            A.CallTo(() => fakeMovie.Title).Returns("Titel");
            A.CallTo(() => fakeMovie.PriceCode).Returns(priceCode);
            /*var fakeRental = A.Fake<IRental>();
            A.CallTo(() => fakeRental.Movie).Returns(fakeMovie);
            A.CallTo(() => fakeRental.DaysRented).Returns(daysRented);*/
            var rental = new Rental(fakeMovie, daysRented);
            _testee.AddRental(rental);
        }
    }
}