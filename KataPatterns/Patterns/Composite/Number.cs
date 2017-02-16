namespace Patterns.Composite
{
    public class Number : IMathOperation
    {
        private readonly int _number;

        public Number(int number)
        {
            _number = number;
        }

        public int Calculate()
        {
            return _number;
        }
    }
}