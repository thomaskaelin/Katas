using System;
using System.Linq;

namespace Chess_Kata
{
    public static class SpaltenExtenstion
    {
        public static Spalte Erhoehen(this Spalte spalte)
        {
            if (spalte.IstLetzteSpalte())
            {
                throw new InvalidOperationException();
            }
            var spalteAlsInt = (int)spalte;

            return (Spalte)(spalteAlsInt + 1);
        }

        public static Spalte Verringern(this Spalte spalte)
        {
            if (spalte.IstErsteSpalte())
            {
                throw  new InvalidOperationException();
            }
            var spalteAlsInt = (int)spalte;

            return (Spalte)(spalteAlsInt - 1);
        }

        public static bool IstLetzteSpalte(this Spalte spalte)
        {
            return spalte == Enum.GetValues(typeof(Spalte)).Cast<Spalte>().Last();
        }

        public static bool IstErsteSpalte(this Spalte spalte)
        {
            return spalte == Enum.GetValues(typeof(Spalte)).Cast<Spalte>().First();
        }
    }
}