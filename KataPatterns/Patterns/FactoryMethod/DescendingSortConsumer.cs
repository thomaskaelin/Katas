namespace Patterns.FactoryMethod
{
    public class DescendingSortConsumer : Consumer
    {
        public override ISortStrategy CreateSortStrategy()
        {
            return new DescendingSortStrategy();
        }
    }
}