namespace Chess_Kata
{
    public enum Spalte
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8
    }

    public static class SpaltenExtenstion
    {
        public static Spalte Erhoehen(this Spalte spalte)
        {
            var spalteAlsInt = (int)spalte;

            return (Spalte)(spalteAlsInt + 1);
        }

        public static Spalte Verringern(this Spalte spalte)
        {
            var spalteAlsInt = (int)spalte;

            return (Spalte)(spalteAlsInt - 1);
        }
    }
}