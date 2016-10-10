namespace Random
{
    public class RandomNumberGenerator
    {
        public virtual int GetRandomNumber(int maxValueExclusive)
        {
            var randomGenerator = new System.Random();
            var randomNumber = randomGenerator.Next(0, maxValueExclusive);

            return randomNumber;
        }
    }
}