using KataYatzy.Contracts;

namespace KataYatzy.Shared
{
    public class Player : IPlayer
    {
        public Player(string name)
        {
            Name = name;
        }

        #region IPlayer

        public string Name { get; }

        #endregion
    }
}