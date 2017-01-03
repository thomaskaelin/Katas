using System;
using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;
using Tennis.StateMachine;

namespace Tennis.Test
{
    [TestFixture]
    public class StateMachineTest
    {
        private StateMachine.StateMachine _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new StateMachine.StateMachine();
        }

        [Test]
        public void DoEvent_WithProperInitializedStateMachine_ModifiesActualState()
        {
            // Arrange
            _testee.SetInitial(State._0to0);
            _testee.AddTransition(State._0to0, Event.AScores, State._15to0);

            // Act
            _testee.DoEvent(Event.AScores);

            // Assert
            _testee.ActualState.Should().Be(State._15to0);
        }

        [Test]
        public void AddTransition_WithSameTransitionAddedTwice_ThrowsInvalidOperationException()
        {
            // Arrange
            Action act = () => _testee.AddTransition(State._0to0, Event.AScores, State._15to0);

            // Act & Assert
            act();
            act.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void DoEvent_WithoutTransitionsForActualState_ThrowsInvalidOperationException()
        {
            // Arrange
            _testee.SetInitial(State._0to0);
            Action act = () => _testee.DoEvent(Event.AScores);

            // Act & Assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void DoEvent_WithoutTransitionsForEvent_ThrowsInvalidOperationException()
        {
            // Arrange
            _testee.SetInitial(State._0to0);
            _testee.AddTransition(State._0to0, Event.AScores, State._15to0);

            Action act = () => _testee.DoEvent(Event.BScores);

            // Act & Assert
            act.ShouldThrow<InvalidOperationException>();
        }
    }
}

