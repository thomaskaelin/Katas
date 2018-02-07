using System;
using System.Linq;
using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;

namespace KataYatzy.Shared
{
    //toDo write unit tests
    public class GameEngine : IGameEngine
    {
        private readonly IScoreBoard _scoreBoard;
        private readonly ITossFactory _tossFactory;
        private IToss _currentToss;
        private IPlayer _currentPlayer;

        public GameEngine() : this(new ScoreBoard(), new TossFactory(5,1,6))
        {
        }

        public GameEngine(IScoreBoard scoreBoard, ITossFactory tossFactory)
        {
            _scoreBoard = scoreBoard;
            _tossFactory = tossFactory;

            InitializeScoreBoard();
        }

        public IScoreBoard ScoreBoard => _scoreBoard;

        public event EventHandler<NewTurnEventArgs> NewTurnStarted;

        public event EventHandler<GameFinishedEventArgs> GameFinished;

        public void StartNewGame()
        {
            _scoreBoard.ClearPoints();
            StartNewTurn();
        }

        public void StartNewTurn()
        {
            // TODO Validierung: Exception wenn StartNewTurn() 2x aufgerufen ohne FinishTurn()
            AssignCurrentPlayer();
            AssignCurrentToss();

            OnNewTurnStarted(_currentPlayer, _currentToss);
        }

        public void FinishTurn(CombinationType combinationType)
        {
            if(_scoreBoard.HasPointsForCombination(_currentPlayer, combinationType))
                return;

            _scoreBoard.AssignToss(_currentPlayer, _currentToss, combinationType);

            if (_scoreBoard.IsGameFinished())
            {
                var winner = GetWinner();
                OnGameFinished(winner);
                return;
            }

            // TODO Unit Test für "Neue Runde" fehlt noch
            StartNewTurn();
        }

        #region Private Methods

        private void InitializeScoreBoard()
        {
            AddPlayer("Loana");
            AddPlayer("Thomas");

            AddCombination(new OnesCombination());
            AddCombination(new ThreeOfAKindCombination());
            AddCombination(new FullHouseCombination());
            AddCombination(new SmallStraightCombination());
            AddCombination(new ChanceCombination());
        }

        private IPlayer GetWinner()
        {
            IPlayer winner = null;
            var maxPoints = -1;

            foreach (var player in _scoreBoard.Players)
            {
                var pointsOfPlayer = _scoreBoard.GetTotalPoints(player).Value;

                if (maxPoints < pointsOfPlayer)
                {
                    maxPoints = pointsOfPlayer;
                    winner = player;
                }
            }

            return winner;
        }
        
        private void AssignCurrentPlayer()
        {
            int nextPlayerIndex;

            if (_currentPlayer == null)
            {
                nextPlayerIndex = 0;
            }
            else
            {
                var currentPlayerIndex = _scoreBoard.Players.IndexOf(_currentPlayer);
                nextPlayerIndex = (currentPlayerIndex + 1) % _scoreBoard.Players.Count;
            }

            _currentPlayer = _scoreBoard.Players[nextPlayerIndex];
        }

        private void AssignCurrentToss()
        {
            _currentToss = _tossFactory.CreateToss();
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
 }