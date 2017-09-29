using FluentAssertions;
using KataProtobuf.Generated;
using NUnit.Framework;

namespace KataProtobuf.Test
{
    [TestFixture]
    public class AddressbookClientFixture
    {
        private AddressbookClient _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new AddressbookClient();
        }

        [Test]
        public void SerializeAndDeserialize_()
        {
            // Arrange
            var john = new Person
            {
                Email = "john.doe@bbv.ch",
                Id = 1,
                Name = "John Doe",
                Phones = { new Person.Types.PhoneNumber { Number = "555-4321", Type = Person.Types.PhoneType.Home } }
            };

            var addressBook = new AddressBook
            {
                People = { john }
            };

            // Act
            var serializedAddressBook = _testee.Serialize(addressBook);
            var deserializedAddressBook = _testee.Deserialize(serializedAddressBook);

            // Assert
            deserializedAddressBook.Equals(addressBook).Should().BeTrue();
            deserializedAddressBook.Should().NotBeSameAs(addressBook);
        }
    }
}
