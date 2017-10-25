using System.Collections.Generic;
using System.Linq;

namespace KataYatzy.Combinations
{
    public class TripletCombination : Combination
    {
        public TripletCombination() : base(CombinationType.Triplet)
        {
        }

        public override IPoints Calculate(IToss toss)
        {
            var groupedDiceValues = GroupByDiceValue(toss);
            if (groupedDiceValues.Values.Any((v) => v >= 3))
            {
                return SumUpAllValues(toss);
            }
            return new Points(0);
        }

        private Dictionary<int,int> GroupByDiceValue(IToss toss)
        {
            var tossedValues = toss.Dices.Select(d => d.Value);
            var distinctTossedValues = tossedValues.Distinct();
            var dict = new Dictionary<int, int>{};
            foreach (var distinctTossedValue in distinctTossedValues)
            {
                var count = tossedValues.Count((tv) => tv == distinctTossedValue);
                dict.Add(distinctTossedValue, count);
            }

            return dict;
        }

        private IPoints SumUpAllValues(IToss toss)
        {
            var sum = toss.Dices.Select(d => d.Value).Sum();
            return new Points(sum);
        }
    }
}