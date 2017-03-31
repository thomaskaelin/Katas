using NUnit.Framework;

namespace Patterns.Test.Observer
{
    [TestFixture]
    public class ObserverFixture 
    {
        private Patterns.Observer.Observer _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Patterns.Observer.Observer();
        }
    }
}