using System;
using Tennis.Contract;

namespace Tennis
{
    public class TennisScorer : ITennisScorer
    {
        private Point _scorePlayerA;
        private Point _scorePlayerB;

        public TennisScorer()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _scorePlayerA = Point._0;
            _scorePlayerB = Point._0;
        }

        public void PlayerAScores()
        {
            PlayerScores(ref _scorePlayerA, ref _scorePlayerB);
        }

        public void PlayerBScores()
        {
            PlayerScores(ref _scorePlayerB, ref _scorePlayerA);
        }

        private static void PlayerScores(ref Point pointOfScoringPlayer, ref Point pointOfOtherPlayer)
        {
            if (pointOfScoringPlayer == Point.Game)
            {
                throw new InvalidOperationException();
            }

            if (pointOfScoringPlayer == Point._40 && pointOfOtherPlayer == Point._40)
            {
                pointOfScoringPlayer = Point.Advantage;
            }
            else if (pointOfOtherPlayer == Point.Advantage)
            {
                pointOfOtherPlayer = Point._40;
            }
            else
            {
                pointOfScoringPlayer = (Point)((int)pointOfScoringPlayer + 1);
            }
        }

        public string GetScore()
        {
            if (_scorePlayerA == Point.Advantage)
            {
                return Point.Advantage.AsString() + "A";
            }

            if (_scorePlayerB == Point.Advantage)
            {
                return Point.Advantage.AsString() + "B";
            }

            if (_scorePlayerA == Point.Game)
            {
                return Point.Game.AsString()+"A";
            }

            if (_scorePlayerB == Point.Game)
            {
                return Point.Game.AsString() + "B";
            }

            if (_scorePlayerA == Point._40 && _scorePlayerB == Point._40)
            {
                return "Deuce";
            }

            return $"{_scorePlayerA.AsString()}-{_scorePlayerB.AsString()}";
        }
    }
}
