using System;
using System.Collections.Generic;
using System.Linq;
using KataYatzy.Contracts;

namespace KataYatzy.Shared
{
    public class ScoreBoard : IScoreBoard
    {
        private readonly List<TossMapping> _tossMappings;

        public ScoreBoard()
        {
            _tossMappings = new List<TossMapping>();
            Players = new List<IPlayer>();
            Combinations = new List<ICombination>();
        }

        #region IScoreBoard

        public List<IPlayer> Players { get; }

        public List<ICombination> Combinations { get; }

        public void AddPlayer(IPlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (Players.Contains(player))
                throw new ArgumentException("Player has already been added.");

            Players.Add(player);
        }

        public void AddCombination(ICombination combination)
        {
            if (combination == null)
                throw new ArgumentNullException(nameof(combination));

            if (Combinations.Contains(combination))
                throw new ArgumentException("Combination has already been added.");

            Combinations.Add(combination);
        }

        public void AssignToss(IPlayer player, IToss toss, CombinationType combinationType)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (!Players.Contains(player))
                throw new ArgumentException("Player has not been added.");

            if (toss == null)
                throw new ArgumentNullException(nameof(toss));

            // ReSharper disable once SimplifyLinqExpression
            if (!Combinations.Any(c => c.Type == combinationType))
                throw new ArgumentException("CombinationType has not been added.");

            if (_tossMappings.Any(tm => tm.Player == player && tm.CombinationType == combinationType))
                throw new ArgumentException("Already assigned a toss for this Player and CombinationType.");

            var newTossMapping = new TossMapping
            {
                Player = player,
                Toss = toss,
                CombinationType = combinationType
            };

            _tossMappings.Add(newTossMapping);
        }

        public IPoints GetPointsForCombination(IPlayer player, CombinationType combinationType)
        {
            if (!HasPointsForCombination(player, combinationType))
                throw new ArgumentException("No toss assigned for this Player and CombinationType.");

            var matchingMapping = _tossMappings.First(mapping => mapping.Player == player && mapping.CombinationType == combinationType);
            var matchingCombination = Combinations.First(combination => combination.Type == combinationType);
            var pointsForCombination = matchingCombination.Calculate(matchingMapping.Toss);

            return pointsForCombination;
        }

        public bool HasPointsForCombination(IPlayer player, CombinationType combinationType)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (!Players.Contains(player))
                throw new ArgumentException("Player has not been added.");

            // ReSharper disable once SimplifyLinqExpression
            if (!Combinations.Any(c => c.Type == combinationType))
                throw new ArgumentException("CombinationType has not been added.");

            return _tossMappings.Any(mapping => mapping.Player == player && mapping.CombinationType == combinationType);
        }

        public IPoints GetTotalPoints(IPlayer player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (!Players.Contains(player))
                throw new ArgumentException("Player has not been added.");

            var matchingMappings = _tossMappings.FindAll(mapping => mapping.Player == player);
            var totalPointsAsInt = matchingMappings.Sum(matchingMapping => GetPointsForCombination(player, matchingMapping.CombinationType).Value);
            var totalPointsAsPoints = new Points(totalPointsAsInt);

            return totalPointsAsPoints;
        }

        public void ClearPoints()
        {
            _tossMappings.Clear();
        }

        #endregion

        #region Private Class TossMapping

        private class TossMapping
        {
            public IPlayer Player { get; set; }

            public IToss Toss { get; set; }

            public CombinationType CombinationType { get; set; }
        }

        #endregion
    }
}