using System.Collections.Generic;

namespace KataYatzy.Contracts
{
    public interface IToss
    {
        List<IDice> Dices { get; }

        void AddDice(IDice dice);
    }
}