using System;
using System.Collections.Generic;
using System.Linq;
using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;

namespace KataYatzy.Shared
{
    //toDo write unit tests
    //toDo introduce interface
    public class GameEngine
    {
        private ScoreBoard _scoreBoard;
        private TossFactory _tossFactory;
        private IToss _currentToss;
        private IPlayer _currentPlayer;

        public GameEngine()
        {
            InitializesGame();
        }

        public IScoreBoard ScoreBoard => _scoreBoard;

        public event EventHandler<NewTurnEventArgs> NewTurnStarted;

        public event EventHandler<GameFinishedEventArgs> GameFinished;

        public void StartNewTurn()
        {
            _currentToss = _tossFactory.CreateToss();
            OnNewTurnStarted(_currentPlayer, _currentToss);
        }

        public void InitializesGame()
        {
            InitializeScoreBoard();
            InitializeTossFactory();
            _currentPlayer = _scoreBoard.Players[0];
        }

        public void FinishTurn(CombinationType combinationType)
        {
            if(_scoreBoard.HasPointsForCombination(_currentPlayer, combinationType))
                return;
            _scoreBoard.AssignToss(_currentPlayer, _currentToss, combinationType);
            if (IsGameFinished())
            {
                var winner = GetWinner();
                OnGameFinished(winner);
                return;
            }
            AssignNewPlayer();
            StartNewTurn();
        }

        #region Private Methods

        private IPlayer GetWinner()
        {
            var maxPoints = 0;
            var winner = _scoreBoard.Players[0];
            foreach (var player in _scoreBoard.Players)
            {
                if (maxPoints < _scoreBoard.GetTotalPoints(player).Value)
                {
                    maxPoints = _scoreBoard.GetTotalPoints(player).Value;
                    winner = player;
                }
            }
            return winner;
        }

        private void AssignNewPlayer()
        {
            var currentPlayerIndex =_scoreBoard.Players.IndexOf(_currentPlayer);
            var nextPlayerIndex = currentPlayerIndex + 1;
            _currentPlayer = nextPlayerIndex < _scoreBoard.Players.Count ? _scoreBoard.Players[nextPlayerIndex] : _scoreBoard.Players[0];
        }

        private bool IsGameFinished()
        {
            var lastPlayer = _scoreBoard.Players.Last();
            var isGameFinished = true;
            foreach (var combination in _scoreBoard.Combinations)
            {
                if (!_scoreBoard.HasPointsForCombination(lastPlayer, combination.Type))
                {
                    isGameFinished = false;
                }
            }
            return isGameFinished;
        }

        private void InitializeScoreBoard()
        {
            _scoreBoard = new ScoreBoard();

            AddPlayer("Loana");
            AddPlayer("Thomas");

            AddCombination(new OnesCombination());
            AddCombination(new ThreeOfAKindCombination());
            AddCombination(new FullHouseCombination());
            AddCombination(new SmallStraightCombination());
            AddCombination(new ChanceCombination());
        }

        private void InitializeTossFactory()
        {
            _tossFactory = new TossFactory(5, 1, 6);
        }

        private void AddPlayer(string playerName)
        {
            _scoreBoard.AddPlayer(new Player(playerName));
        }

        private void AddCombination(ICombination combination)
        {
            _scoreBoard.AddCombination(combination);
        }

        #endregion

        protected virtual void OnNewTurnStarted(IPlayer player, IToss toss)
        {
            var eventArgs = new NewTurnEventArgs(player, toss);
            NewTurnStarted?.Invoke(this, eventArgs);
        }

        protected virtual void OnGameFinished(IPlayer player)
        {
            var gameFinishedEventArgs = new GameFinishedEventArgs(player);
            GameFinished?.Invoke(this, gameFinishedEventArgs);
        }
    }

    public sealed class NewTurnEventArgs : EventArgs
    {
        public NewTurnEventArgs(IPlayer player, IToss toss)
        {
            Player = player;
            Toss = toss;
        }

        public IPlayer Player { get; private set; }

        public IToss Toss { get; private set; }
    }

    public sealed class GameFinishedEventArgs : EventArgs
    {
        public GameFinishedEventArgs(IPlayer winner)
        {
            Winner = winner;
        }

        public IPlayer Winner { get; private set; }
    }
}