using System.Collections.Generic;
using System.Linq;

namespace KataYatzy.Combinations
{
    public class TripletCombination : Combination
    {
        public TripletCombination() : base(CombinationType.Triplet)
        {
        }

        #region Overrides

        public override IPoints Calculate(IToss toss)
        {
            var groupedDiceValues = GroupByDiceValue(toss);

            if (groupedDiceValues.Values.Any(v => v >= 3))
            {
                return SumUpAllValues(toss);
            }

            return new Points(0);
        }

        #endregion

        #region Private Methods

        private static Dictionary<int,int> GroupByDiceValue(IToss toss)
        {
            // TODO Diese Methode könnte evtl. in der Basis benötigt werden
            var grouped = new Dictionary<int, int>();
            var tossedValues = toss.Dices.Select(d => d.Value).ToList();
            var distinctTossedValues = tossedValues.Distinct();

            foreach (var distinctTossedValue in distinctTossedValues)
            {
                var count = tossedValues.Count(tv => tv == distinctTossedValue);
                grouped.Add(distinctTossedValue, count);
            }

            return grouped;
        }

        private static IPoints SumUpAllValues(IToss toss)
        {
            var sumAsInt = toss.Dices.Select(d => d.Value).Sum();
            var sumAsPoints = new Points(sumAsInt);

            return sumAsPoints;
        }

        #endregion
    }
}