using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using KataYatzy.Contracts;
using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class GameEngineFixture
    {
        private GameEngine _testee;

        private List<NewTurnEventArgs> _newTurnEventArgs;
        private List<GameFinishedEventArgs> _gameFinishedEventArgs;

        private IScoreBoard _fakeScoreBoard;
        private ITossFactory _fakeTossFactory;

        [SetUp]
        public void SetUp()
        {
            _newTurnEventArgs = new List<NewTurnEventArgs>();
            _gameFinishedEventArgs = new List<GameFinishedEventArgs>();

            _fakeScoreBoard = CreateFakeScoreBoard();
            _fakeTossFactory = A.Fake<ITossFactory>();

            _testee = new GameEngine(_fakeScoreBoard, _fakeTossFactory);
            _testee.NewTurnStarted += (sender, eventArgs) => { _newTurnEventArgs.Add(eventArgs); };
            _testee.GameFinished += (sender, eventArgs) => { _gameFinishedEventArgs.Add(eventArgs); };
        }

        [Test]
        public void Constructor_CallsAddPlayer_OnScoreBoard()
        {
            // Assert
            PlayerShouldHaveBeenAddedToScoreBoard("Loana");
            PlayerShouldHaveBeenAddedToScoreBoard("Thomas");
        }

        [Test]
        public void Constructor_CallsAddCombination_OnScoreBoard()
        {
            // Assert
            CombinationShouldHaveBeenAddedToScoreBoard(CombinationType.Ones);
            CombinationShouldHaveBeenAddedToScoreBoard(CombinationType.ThreeOfAKind);
            CombinationShouldHaveBeenAddedToScoreBoard(CombinationType.FullHouse);
            CombinationShouldHaveBeenAddedToScoreBoard(CombinationType.SmallStraight);
            CombinationShouldHaveBeenAddedToScoreBoard(CombinationType.Chance);
        }

        [Test]
        public void StartNewGame_CallsClearPoints_OnScoreBoard()
        {
            // Act
            _testee.StartNewGame();

            // Assert
            A.CallTo(() => _fakeScoreBoard.ClearPoints()).MustHaveHappened();
        }

        [Test]
        public void StartNewGame_StartNewTurn()
        {
            // Act
            _testee.StartNewGame();

            // Assert
            _newTurnEventArgs.Count.Should().Be(1);
        }

        [Test]
        public void StartNewTurn_SetCurrentPlayerAndCurrentToss()
        {
            // Arrange
            var fakeToss = A.Fake<IToss>();
            A.CallTo(() => _fakeTossFactory.CreateToss()).Returns(fakeToss);

            // Act
            _testee.StartNewTurn();

            // Assert
            A.CallTo(() => _fakeTossFactory.CreateToss()).MustHaveHappened();
            _newTurnEventArgs[0].Toss.Should().BeSameAs(fakeToss);
            _newTurnEventArgs[0].Player.Name.Should().Be("Loana");
        }

        [Test]
        public void FinishTurn_WithUnassignedCombination_CallsAssignToss()
        {
            // TODO Test verbessern: Korrekte Parameter für AssignToss() prüfen
            // Act
            _testee.FinishTurn(CombinationType.Ones);

            // Assert
            A.CallTo(() => _fakeScoreBoard.AssignToss(A<IPlayer>.Ignored, A<IToss>.Ignored, CombinationType.Ones)).MustHaveHappened();
        }

        [Test]
        public void FinishTurn_WithAlreadyAssignedCombination_DoesNotCallAssignToss()
        {
            // TODO Test verbessern: Korrekte Parameter für HasPointsForCombination() prüfen
            // Arrange
            A.CallTo(() => _fakeScoreBoard.HasPointsForCombination(A<IPlayer>.Ignored, CombinationType.Ones)).Returns(true);

            // Act
            _testee.FinishTurn(CombinationType.Ones);

            // Assert
            A.CallTo(() => _fakeScoreBoard.AssignToss(A<IPlayer>.Ignored, A<IToss>.Ignored, CombinationType.Ones)).MustNotHaveHappened();
        }

        [Test]
        public void FinishTurn_WithValidUnassignedCombination_And_WhenGameFinished_RaisesGameFinishedEvent()
        {
            // Arrange
            var player1 = _fakeScoreBoard.Players[0];
            var player2 = _fakeScoreBoard.Players[0];

            var fakePoints1 = CreateFakePoints(99);
            var fakePoints2 = CreateFakePoints(2);

            A.CallTo(() => _fakeScoreBoard.IsGameFinished()).Returns(true);
            A.CallTo(() => _fakeScoreBoard.GetTotalPoints(player1)).Returns(fakePoints1);
            A.CallTo(() => _fakeScoreBoard.GetTotalPoints(player2)).Returns(fakePoints2);

            // Act
            _testee.FinishTurn(CombinationType.Ones);

            // Assert
            _gameFinishedEventArgs.Count.Should().Be(1);
            _gameFinishedEventArgs[0].Winner.Should().BeSameAs(player1);
        }

        #region Private Methods

        private IScoreBoard CreateFakeScoreBoard()
        {
            var fakeScoreBoard = A.Fake<IScoreBoard>();

            var players = new List<IPlayer>();
            A.CallTo(() => fakeScoreBoard.Players).Returns(players);
            A.CallTo(() => fakeScoreBoard.AddPlayer(A<IPlayer>.Ignored)).Invokes((IPlayer player) =>
            {
                fakeScoreBoard.Players.Add(player);
            });

            var combinations = new List<ICombination>();
            A.CallTo(() => fakeScoreBoard.Combinations).Returns(combinations);
            A.CallTo(() => fakeScoreBoard.AddCombination(A<ICombination>.Ignored)).Invokes((ICombination combination) =>
            {
                fakeScoreBoard.Combinations.Add(combination);
            });

            return fakeScoreBoard;
        }

        private IPoints CreateFakePoints(int points)
        {
            // TODO Ersetzen mit FakeCreator
            var fakePoints = A.Fake<IPoints>();

            A.CallTo(() => fakePoints.Value).Returns(points);

            return fakePoints;
        }

        private void PlayerShouldHaveBeenAddedToScoreBoard(string expectedPlayerName)
        {
            A.CallTo(() => _fakeScoreBoard.AddPlayer(A<IPlayer>.That.Matches(p => p.Name == expectedPlayerName))).MustHaveHappened();
        }

        private void CombinationShouldHaveBeenAddedToScoreBoard(CombinationType expectedCombinationType)
        {
            A.CallTo(() => _fakeScoreBoard.AddCombination(A<ICombination>.That.Matches(c => c.Type == expectedCombinationType))).MustHaveHappened();
        }

        #endregion

    }
}