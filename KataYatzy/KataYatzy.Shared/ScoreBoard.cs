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
            // TODO Validierung: Was passiert, wenn Player nicht vorhanden ist?
            // TODO Validierung: Was passiert, wenn keine Combination für den CombinationType registriert ist?
            // TODO Validierung: Was passiert, wenn für den CombinationType schon ein Toss zugewiesen wurde?
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
            // TODO Validierung: Was passiert, wenn Player nicht vorhanden ist?
            // TODO Validierung: Was passiert, wenn keine Combination für den CombinationType registriert ist?
            // TODO Validierung: Was passiert, wenn keine Punkte für den CombinationType hinzugefügt wurden?
            var matchingMapping = _tossMappings.First(mapping => mapping.Player == player && mapping.CombinationType == combinationType);
            var matchingCombination = Combinations.First(combination => combination.Type == combinationType);
            var pointsForCombination = matchingCombination.Calculate(matchingMapping.Toss);

            return pointsForCombination;
        }

        public bool HasPointsForCombination(IPlayer player, CombinationType combinationType)
        {
            return _tossMappings.Any(mapping => mapping.Player == player && mapping.CombinationType == combinationType);
        }

        public IPoints GetTotalPoints(IPlayer player)
        {
            // TODO Validierung: Was passiert, wenn Player nicht vorhanden ist?
            var matchingMappings = _tossMappings.FindAll(mapping => mapping.Player == player);
            var totalPointsAsInt = matchingMappings.Sum(matchingMapping => GetPointsForCombination(player, matchingMapping.CombinationType).Value);
            var totalPointsAsPoints = new Points(totalPointsAsInt);

            return totalPointsAsPoints;
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