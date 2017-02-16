namespace Patterns.FactoryMethod
{
    public class AscendingSortConsumer : Consumer
    {
        public override ISortStrategy CreateSortStrategy()
        {
            return new AscendingSortStrategy();
        }
    }
}