using FakeItEasy;
using NUnit.Framework;
using Patterns.Command;

namespace Patterns.Test.Command
{
    [TestFixture]
    public class WikiCommandManagerFixture
    {
        private WikiCommandManager _testee;
        private ICommand _fakeCommand;

        [SetUp]
        public void SetUp()
        {
            _testee = new WikiCommandManager();
            _fakeCommand = A.Fake<ICommand>();
        }

        [Test]
        public void Execute_CallsDoOnCommand()
        {
            // Act
            _testee.Execute(_fakeCommand);

            // Assert
            A.CallTo(() => _fakeCommand.Do()).MustHaveHappened();
        }

    }
}