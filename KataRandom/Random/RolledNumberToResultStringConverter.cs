namespace Random
{
    public class RolledNumberToResultStringConverter
    {
        public virtual string Convert(int rolledNumber)
        {
            switch (rolledNumber)
            {
                case 1:
                    return "Oh no! You got a 1. :-(";
                case 2:
                    return "Try harder! You only got a 2.";
                case 3:
                    return "You are below average! You got a 3.";
                case 4:
                    return "You are above average! You got a 4.";
                case 5:
                    return "Nice one! You got a 5.";
                case 6:
                    return "Awesome roll! You got a 6. :-)";
                default:
                    throw new InvalidNumberException();
            }
        }
    }
}