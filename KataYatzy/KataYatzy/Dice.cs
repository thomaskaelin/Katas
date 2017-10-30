namespace KataYatzy
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