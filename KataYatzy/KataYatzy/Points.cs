namespace KataYatzy
{
    public class Points : IPoints
    {
        public Points(int value)
        {
            Value = value;
        }
        public int Value { get; }
    }
}