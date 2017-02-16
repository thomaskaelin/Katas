using System;

namespace Patterns.Decorator
{
    public class ExceptionDecorator : ICalculator
    {
        public const float DivideByZeroResult = 99;

        private readonly ICalculator _decoratedCalculator;

        public ExceptionDecorator(ICalculator decoratedCalculator)
        {
            _decoratedCalculator = decoratedCalculator;
        }

        public float Divide(int value1, int value2)
        {
            try
            {
                return _decoratedCalculator.Divide(value1, value2);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine(exception);
                return DivideByZeroResult;
            }
        }
    }
}