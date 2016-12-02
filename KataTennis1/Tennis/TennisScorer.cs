using System;

namespace Tennis
{
    public class TennisScorer
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
            /*if (_scorePlayerA == Point.Game)
            {
                throw new InvalidOperationException();
            }*/
            PlayerScores(ref _scorePlayerB, ref _scorePlayerA);
        }

        public void PlayerBScores()
        {
            PlayerScores(ref _scorePlayerA, ref _scorePlayerB);
        }

        private static void PlayerScores(ref Point firstScore, ref Point secondScore)
        {
            if (secondScore == Point.Game)
            {
                throw new InvalidOperationException();
            }
            if (firstScore == Point._40 && secondScore == Point._40)
            {
                secondScore = Point.Advantage;
            }
            else if (firstScore == Point.Advantage)
            {
                firstScore = Point._40;
            }
            else
            {
                secondScore = (Point)((int)secondScore + 1);
            }
        }

        public string GetScore()
        {
            var score = string.Empty;
            if (_scorePlayerA == Point.Advantage)
            {
                score = Point.Advantage.AsString() + "A";
            }
            else if (_scorePlayerB == Point.Advantage)
            {
                score = Point.Advantage.AsString() + "B";
            }
            else if (_scorePlayerA == Point.Game)
            {
                score = Point.Game.AsString()+"A";
            }
            else if (_scorePlayerB == Point.Game)
            {
                score = Point.Game.AsString() + "B";
            }
            else 
            {
                score = $"{_scorePlayerA.AsString()}-{_scorePlayerB.AsString()}";
            }
            return score;
        }


    }
}
