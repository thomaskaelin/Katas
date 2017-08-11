namespace KataDatastructures
{
    public interface IList<TItem>
    {
        TItem this[int key] { get; set; }

        void Add(TItem item);
        TItem Get(int index);
        void Remove(int index);
        void Set(int index, TItem item);
        int Size();
    }
}