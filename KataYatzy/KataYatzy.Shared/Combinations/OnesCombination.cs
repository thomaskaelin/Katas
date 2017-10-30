using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;

namespace KataYatzy.Shared.Combinations
{
    public class OnesCombination : Combination
    {
        public OnesCombination() : base(CombinationType.Ones)
        {
        }

        #region Overrides

        protected override int Calculate(TossAnalyzer tossAnalyzer)
        {
            return tossAnalyzer.CountOccurencesOfDiceValue(1);
        }

        #endregion
    }
}