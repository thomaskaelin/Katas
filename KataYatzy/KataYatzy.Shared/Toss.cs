using System.Collections.Generic;
using KataYatzy.Contracts;

namespace KataYatzy.Shared
{
    public class Toss : IToss
    {
        private readonly List<IDice> _dices;

        public Toss()
        {
            _dices = new List<IDice>();
        }

        #region IToss

        public IReadOnlyList<IDice> Dices => _dices.AsReadOnly();

        #endregion

        #region Public Methods

        public void AddDice(IDice dice)
        {
            _dices.Add(dice);
        }

        #endregion
    }
}