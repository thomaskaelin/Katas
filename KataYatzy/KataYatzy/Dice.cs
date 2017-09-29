namespace KataYatzy
{
    public class Dice : IDice
    {
        public Dice(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}