using System;
using FluentAssertions;
using Xunit;

namespace KataAOP.Test
{
    public class ExceptionSwallowerFixture
    {
        private ExceptionSwallower _testee;

        public ExceptionSwallowerFixture()
        {
              _testee = new ExceptionSwallower();
        }

        [Fact]
        public void ThrowException_ThrowsException()
        {
            // Arrange
            Action action = () => _testee.ThrowException();

            // Act & Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowExceptionWithAttribute_ThrowsNoException()
        {
            // Arrange
            Action action = () => _testee.ThrowExceptionWithAttribute();

            // Act & Assert
            action.ShouldNotThrow<ArgumentNullException>();
        }
    }
}
