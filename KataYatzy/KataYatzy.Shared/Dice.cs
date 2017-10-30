using KataYatzy.Contracts;

namespace KataYatzy.Shared
{
    public class Dice : IDice
    {
        public Dice(int value)
        {
            Value = value;
        }

        #region IDice

        public int Value { get; }

        #endregion
    }
}