namespace Random
{
    public class RandomIndexGenerator
    {

        public virtual int GetRandomIndex(int maxValue)
        {
            var randomGenerator = new System.Random();
            int randomIndex = randomGenerator.Next(0, maxValue);
            return randomIndex;
        }
    }
}