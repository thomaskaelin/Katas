using System.Collections.Generic;

namespace KataYatzy.Contracts
{
    public interface IToss
    {
        IReadOnlyList<IDice> Dices { get; }
    }
}