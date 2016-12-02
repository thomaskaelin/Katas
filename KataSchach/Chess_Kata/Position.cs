using System;

namespace Chess_Kata
{
    public class Position : Object,IEquatable<Position>
    {
        public Position(Spalte spalte, Zeile zeile)
        {
            Zeile = zeile;
            Spalte = spalte;
        }

        public virtual Zeile Zeile { get; }

        public virtual Spalte Spalte { get; }

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

        public bool Equals(Position other)
        {
            return Spalte == other.Spalte && Zeile == other.Zeile;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Position position = (Position) obj;
            return Equals(position);
        }

        public override int GetHashCode()
        {
            int spalteAlsInt = (int) Spalte;
            int zeileAlsInt = (int) Zeile;
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + spalteAlsInt.GetHashCode();
                hash = hash * 23 + zeileAlsInt.GetHashCode();
                return hash;
            }
            
           }
    }
}