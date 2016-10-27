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

        public Position NachOben()
        {
            return new Position(Spalte, Zeile.Erhoehen());
        }

        public Position NachLinks()
        {
            return new Position(Spalte.Verringern(), Zeile);
        }

        public Position NachRechts()
        {
            return new Position(Spalte.Erhoehen(), Zeile);
        }

        public Position NachUnten()
        {
            return new Position(Spalte, Zeile.Verringern());
        }
    }
}