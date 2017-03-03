namespace Patterns.Abstract_Factory
{
    public interface IFactory
    {
        ISortStrategy CreateSortStrategy();

        IModifierStrategy CreateModifierStrategy();
    }
}