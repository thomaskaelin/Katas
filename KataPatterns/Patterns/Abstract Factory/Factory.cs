namespace Patterns.Abstract_Factory
{
    public class Factory : IFactory
    {
        public ISortStrategy CreateSortStrategy()
        {
            return new SortStrategy();
        }

        public IModifierStrategy CreateModifierStrategy()
        {
            return new ModifierStrategy();
        }
    }
}