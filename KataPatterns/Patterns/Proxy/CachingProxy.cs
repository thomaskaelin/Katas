namespace Patterns.Proxy
{
    public class CachingProxy : ICalculator
    {
        private readonly ICalculator _calculator;

        private int? _calculateResult;

        public CachingProxy(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Calculate()
        {
            if (!_calculateResult.HasValue)
                _calculateResult = _calculator.Calculate();

            return _calculateResult.Value;

        }
    }
}