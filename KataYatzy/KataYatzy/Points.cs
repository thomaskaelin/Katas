namespace KataYatzy
{
    public class Points : IPoints
    {
        public Points(int value)
        {
            Value = value;
        }

        #region IPoints

        public int Value { get; }

        #endregion
    }
}