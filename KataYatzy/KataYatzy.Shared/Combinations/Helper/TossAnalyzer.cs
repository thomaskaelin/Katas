using System.Collections.Generic;
using System.Linq;
using KataYatzy.Contracts;

namespace KataYatzy.Shared.Combinations.Helper
{
    public class TossAnalyzer
    {
        private readonly IDictionary<int, int> _diceValueToOccurences;

        public TossAnalyzer(IToss toss)
        {
            Toss = toss;
            _diceValueToOccurences = CountOccurencesPerDiceValue(toss);
        }

        #region Public Properties and Methods

        /// <summary>
        /// Gets the <see cref="IToss"/> analyzed by this object.
        /// </summary>
        public IToss Toss { get; }

        /// <summary>
        /// Returns the sum of all dice values within the analyzed <see cref="IToss"/>.
        /// </summary>
        /// <returns>see summary tag</returns>
        public int SumOfAllDiceValues()
        {
            return _diceValueToOccurences.Sum(kvp => kvp.Key * kvp.Value);
        }

        /// <summary>
        /// Returns the number of occurences of a dice value within the analyzed <see cref="IToss"/>.
        /// When a dice value did not occured within the toss, zero is returnedl
        /// </summary>
        /// <param name="diceValue">The dice value to search within the toss.</param>
        /// <returns>see summary tag</returns>
        public int CountOccurencesOfDiceValue(int diceValue)
        {
            return _diceValueToOccurences.ContainsKey(diceValue) ? _diceValueToOccurences[diceValue] : 0;
        }

        /// <summary>
        /// Returns true, if any dice value did occur at least <paramref name="numberOfTimes"/> times within
        /// the analyzed <see cref="IToss"/>, otherwise false.
        /// </summary>
        /// <param name="numberOfTimes">The limit for the check.</param>
        /// <returns>see summary tag</returns>
        public bool AnyDiceValueOccursAtLeastXTimes(int numberOfTimes)
        {
            return _diceValueToOccurences.Values.Any(occurences => occurences >= numberOfTimes);
        }

        public bool AreThereXDiceValuesInSequence(int sequenceLength)
        {
            if (_diceValueToOccurences.Count < sequenceLength)
                return false;

            var diceValues = _diceValueToOccurences.Keys;

            var sequenceLengthCounter = 1; 
            int? lastDiceValue = null;

            foreach (var diceValue in diceValues)
            {
                if (lastDiceValue.HasValue)
                {
                    if (lastDiceValue + 1 == diceValue)
                    {
                        sequenceLengthCounter++;
                    }
                    else
                    {
                        sequenceLengthCounter = 1;
                    }
                }

                if (sequenceLengthCounter == sequenceLength)
                    return true;

                lastDiceValue = diceValue;
            }

            return false;
        }

        public IDictionary<int, int> GetOccurencesPerDiceValue()
        {
            return _diceValueToOccurences;
        }

        #endregion

        #region Private Methods

        private static Dictionary<int, int> CountOccurencesPerDiceValue(IToss toss)
        {
            var occurencesPerDiceValue = new Dictionary<int, int>();

            var tossedDiceValues = toss.Dices.Select(d => d.Value).ToList();
            var distinctTossedDiceValues = tossedDiceValues.Distinct().OrderBy(v => v);

            foreach (var distinctTossedDiceValue in distinctTossedDiceValues)
            {
                var occurences = tossedDiceValues.Count(tv => tv == distinctTossedDiceValue);
                occurencesPerDiceValue.Add(distinctTossedDiceValue, occurences);
            }

            return occurencesPerDiceValue;
        }

        #endregion
    }
}
