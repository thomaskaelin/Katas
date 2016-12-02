using System;
using System.Linq;

namespace Chess_Kata
{
    public static class ZeilenExtensions
    {
        public static Zeile Erhoehen(this Zeile zeile)
        {
            if (zeile.IstLetzteZeile())
            {
                throw new InvalidOperationException("Erhöhen ungültig weil auf letzter Zeile");
            } 
            var zeileAlsInt = (int) zeile;

            return (Zeile)(zeileAlsInt + 1);
        }

        public static Zeile Verringern(this Zeile zeile)
        {
            if (zeile.IstErsteZeile())
            {
                throw new InvalidOperationException("Verringern ungültig weil auf erster Zeile");
            }
            var zeileAlsInt = (int) zeile;

            return (Zeile) (zeileAlsInt - 1);
        }

        public static bool IstLetzteZeile(this Zeile zeile)
        {
            return zeile == Enum.GetValues(typeof(Zeile)).Cast<Zeile>().Last();
        }

        public static bool IstErsteZeile(this Zeile zeile)
        {
            return zeile == Enum.GetValues(typeof(Zeile)).Cast<Zeile>().First();
        }
    }
}