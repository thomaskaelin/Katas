using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations.Helper;

namespace KataYatzy.Shared.Combinations
{
    public class SmallStreetCombination : Combination
    {
        public SmallStreetCombination() : base(CombinationType.SmallStreet)
        {
        }

        protected override int Calculate(TossAnalyzer tossAnalyzer)
        {
            return tossAnalyzer.AreThereXDiceValuesInSequence(4) ? 30 : 0;
        }
    }
}