namespace Chess_Kata
{
    public class Bauer : IFigur
    {
        public Bauer(Farbe farbe)
        {
            Farbe = farbe;
        }

        public Farbe Farbe { get; }
    }
}