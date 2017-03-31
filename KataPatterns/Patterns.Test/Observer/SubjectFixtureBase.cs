using FakeItEasy;
using NUnit.Framework;
using Patterns.Observer;

namespace Patterns.Test.Observer
{
    public abstract class SubjectFixtureBase
    {
        private Subject _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = CreateTestee();
        }
        
        public abstract Subject CreateTestee();
        
    }
}