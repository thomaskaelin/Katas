using System.Linq;
using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;

namespace KataYatzy.Shared.Combinations
{
    public class FullHouseCombination : Combination
    {
        public FullHouseCombination() : base(CombinationType.FullHouse)
        {
        }

        #region Overrides

        protected override int Calculate(TossAnalyzer tossAnalyzer)
        {
            var occurencesPerDiceValue = tossAnalyzer.GetOccurencesPerDiceValue();
            if(occurencesPerDiceValue.Count != 2)
                return 0;
            if (occurencesPerDiceValue.Values.First() == 1)
                return 0;
            if (occurencesPerDiceValue.Values.First() == 4)
                return 0;
            return 25;
        }

        #endregion


    }
}