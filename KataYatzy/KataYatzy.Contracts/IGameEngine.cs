using System;

namespace KataYatzy.Contracts
{
    public interface IGameEngine
    {
        event EventHandler<NewTurnEventArgs> NewTurnStarted;

        event EventHandler<GameFinishedEventArgs> GameFinished;

        IScoreBoard ScoreBoard { get; }
        
        void InitializesGame();

        void StartNewTurn();
        
        void FinishTurn(CombinationType combinationType);
    }

    public sealed class GameFinishedEventArgs : EventArgs
    {
        public GameFinishedEventArgs(IPlayer winner)
        {
            Winner = winner;
        }

        public IPlayer Winner { get; private set; }
    }

    public sealed class NewTurnEventArgs : EventArgs
    {
        public NewTurnEventArgs(IPlayer player, IToss toss)
        {
            Player = player;
            Toss = toss;
        }

        public IPlayer Player { get; private set; }

        public IToss Toss { get; private set; }
    }
}