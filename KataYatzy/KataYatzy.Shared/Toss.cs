using System.Collections.Generic;
using KataYatzy.Contracts;

namespace KataYatzy.Shared
{
    public class Toss : IToss
    {
        public Toss()
        {
            Dices = new List<IDice>();
        }

        #region IToss

        public List<IDice> Dices { get; }

        public void AddDice(IDice dice)
        {
            // TODO max 5 Würfel?!?
            Dices.Add(dice);
        }

        #endregion
    }
}