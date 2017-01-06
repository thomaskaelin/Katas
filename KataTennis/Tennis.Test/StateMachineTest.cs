using System;
using FluentAssertions;
using NUnit.Framework;
using Tennis.Contract;
using Tennis.StateMachine.Manual;

namespace Tennis.Test
{
    [TestFixture]
    public class StateMachineTest
    {
        private StateMachine<TennisState, TennisEvent> _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new StateMachine<TennisState, TennisEvent>();
        }

        [Test]
        public void DoEvent_WithProperInitializedStateMachine_ModifiesActualState()
        {
            // Arrange
            _testee.SetInitial(TennisState._0to0);
            _testee.AddTransition(TennisState._0to0, TennisEvent.AScores, TennisState._15to0);

            // Act
            _testee.DoEvent(TennisEvent.AScores);

            // Assert
            _testee.ActualState.Should().Be(TennisState._15to0);
        }

        [Test]
        public void AddTransition_WithSameTransitionAddedTwice_ThrowsInvalidOperationException()
        {
            // Arrange
            Action act = () => _testee.AddTransition(TennisState._0to0, TennisEvent.AScores, TennisState._15to0);

            // Act & Assert
            act();
            act.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void DoEvent_WithoutTransitionsForActualState_ThrowsInvalidOperationException()
        {
            // Arrange
            _testee.SetInitial(TennisState._0to0);
            Action act = () => _testee.DoEvent(TennisEvent.AScores);

            // Act & Assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void DoEvent_WithoutTransitionsForEvent_ThrowsInvalidOperationException()
        {
            // Arrange
            _testee.SetInitial(TennisState._0to0);
            _testee.AddTransition(TennisState._0to0, TennisEvent.AScores, TennisState._15to0);

            Action act = () => _testee.DoEvent(TennisEvent.BScores);

            // Act & Assert
            act.ShouldThrow<InvalidOperationException>();
        }
    }
}