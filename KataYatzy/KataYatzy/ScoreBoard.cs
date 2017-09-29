using System.Collections.Generic;
using System.Linq;

namespace KataYatzy
{
    public class ScoreBoard : IScoreBoard
    {
        private List<TossMapping> _tossMappings;
        public ScoreBoard()
        {
            Player = new List<IPlayer>();
            Combinations = new List<ICombination>();
            _tossMappings = new List<TossMapping>();
        }
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
            var matchingMapping = _tossMappings.FirstOrDefault(
                (mapping) => mapping.Player == player && mapping.CombinationType == combinationType);
            var matchingCombination = Combinations.FirstOrDefault((combination) => combination.Type == combinationType);
            return matchingCombination.Calculate(matchingMapping.Toss);
        }

        public IPoints GetTotalPoints(IPlayer player)
        {
            var matchingMappings = _tossMappings.FindAll((mapping) => mapping.Player == player);
            var points = matchingMappings.Sum(matchingMapping => GetPointsForCombination(player, matchingMapping.CombinationType).Value);
            return new Points(points);
        }

        private class TossMapping
        {
            public IPlayer Player { get; set; }

            public IToss Toss { get; set; }

            public CombinationType CombinationType { get; set; }
            
        }
    }
}
