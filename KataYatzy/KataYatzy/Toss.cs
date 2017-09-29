using System.Collections.Generic;

namespace KataYatzy
{
    public class Toss : IToss
    {
        public Toss()
        {
            Dices = new List<IDice>();
        }
        public List<IDice> Dices { get; }

        public void AddDice(IDice dice)
        {
            // TODO max 5 Würfel?!?
            Dices.Add(dice);
        }


    }
}