using System;
using KataYatzy.Contracts;

namespace KataYatzy.Shared
{
    public class TossFactory : ITossFactory
    {
        private readonly int _numberOfDices;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly Random _random;

        public TossFactory(int numberOfDices, int minValue, int maxValue)
        {
            _numberOfDices = numberOfDices;
            _minValue = minValue;
            _maxValue = maxValue;
            _random = new Random();
        }

        #region ITossFactory

        public IToss CreateToss()
        {
            var toss = new Toss();
            for (var i = 1; i <= _numberOfDices; i++)
            {
                var dice = new Dice(_random.Next(_minValue, _maxValue + 1));
                toss.AddDice(dice);
            }

            return toss;
        }

        #endregion
    }
}