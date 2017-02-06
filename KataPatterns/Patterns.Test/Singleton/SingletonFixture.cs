using FluentAssertions;
using NUnit.Framework;

namespace Patterns.Test.Singleton
{
    [TestFixture]
    public class SingletonFixture
    {
        [Test]
        public void Instance_WhenCalledTwice_ReturnsSameObject()
        {
            // act
            var result1 = Patterns.Singleton.Singleton.Instance;
            var result2 = Patterns.Singleton.Singleton.Instance;

            // assert
            result1.Should().BeSameAs(result2);
        }
    }
}