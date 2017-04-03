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

        [Test]
        public void Undo_CallsUndoOnCommand_ExpectedNumberOfTimes()
        {
            // Arrange
            const uint numberOfSteps = 3;
            _testee.Execute(_fakeCommand);
            _testee.Execute(_fakeCommand);
            _testee.Execute(_fakeCommand);
            
            // Act
            _testee.Undo(numberOfSteps);

            // Assert
            A.CallTo(() => _fakeCommand.Undo()).MustHaveHappened(Repeated.Exactly.Times((int)numberOfSteps));
        }

        [Test]
        public void Redo_CallsDoOnCommand()
        {
            // Arrange
            const uint numberOfSteps = 3;
            _testee.Execute(_fakeCommand);
            _testee.Execute(_fakeCommand);
            _testee.Execute(_fakeCommand);
            _testee.Undo(numberOfSteps);

            // Act
            _testee.Redo(numberOfSteps);

            // Assert
            A.CallTo(() => _fakeCommand.Do()).MustHaveHappened(Repeated.Exactly.Times(6));
        }

    }
}