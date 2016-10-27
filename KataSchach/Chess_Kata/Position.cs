namespace Chess_Kata
{
    public class Position
    {
        public Position(Spalte spalte, Zeile zeile)
        {
            Zeile = zeile;
            Spalte = spalte;
        }

        public virtual Zeile Zeile { get; private set; }
        public virtual Spalte Spalte { get; private set; }
    }
}