using System.Collections.Generic;

namespace KataYatzy
{
    public interface IToss
    {
        List<IDice> Dices { get; }

        void AddDice(IDice dice);
    }
}