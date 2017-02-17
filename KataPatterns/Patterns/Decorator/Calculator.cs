namespace Patterns.Decorator
{
    public class Calculator : ICalculator
    {
        public float Divide(int value1, int value2)
        {
            return value1 / value2;
        }
    }
}