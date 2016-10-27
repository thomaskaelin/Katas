namespace Chess_Kata
{
    public class Turm : IFigur
    {
        public Turm(Farbe farbe)
        {
            Farbe = farbe;
        }

        public Farbe Farbe { get; }
    }
}