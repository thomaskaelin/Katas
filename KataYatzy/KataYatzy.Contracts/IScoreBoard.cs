using System.Collections.Generic;

namespace KataYatzy.Contracts
{
    public interface IScoreBoard
    {
        List<IPlayer> Players { get; }

        List<ICombination> Combinations { get; }

        void AddPlayer(IPlayer player);

        void AddCombination(ICombination combination);

        void AssignToss(IPlayer player, IToss toss, CombinationType ones);

        IPoints GetPointsForCombination(IPlayer player, CombinationType combinationType);

        bool HasPointsForCombination(IPlayer player, CombinationType combinationType);

        IPoints GetTotalPoints(IPlayer player);

        void ClearPoints();
    }
}