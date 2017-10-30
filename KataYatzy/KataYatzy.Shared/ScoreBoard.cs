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
            Player = new List<IPlayer>();
            Combinations = new List<ICombination>();
            _tossMappings = new List<TossMapping>();
        }

        #region IScoreBoard

        public List<IPlayer> Player { get; }

        public List<ICombination> Combinations { get; }

        public void AddPlayer(IPlayer player)
        {
            Player.Add(player);
        }

        public void AddCombination(ICombination combination)
        {
            Combinations.Add(combination);
        }

        public void AssignToss(IPlayer player, IToss toss, CombinationType combinationType)
        {
            // TODO Was passiert wenn kein Player
            // TODO Was passiert wenn CombinationType nicht exisitert
            // TODO Was passiert wenn für CombinationType schon ein Toss exisitiert
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
            // TODO Was passiert wenn CombinationType nicht exisitert
            var matchingMapping = _tossMappings.First(mapping => mapping.Player == player && mapping.CombinationType == combinationType);
            var matchingCombination = Combinations.First(combination => combination.Type == combinationType);
            var pointsForCombination = matchingCombination.Calculate(matchingMapping.Toss);

            return pointsForCombination;
        }

        public IPoints GetTotalPoints(IPlayer player)
        {
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