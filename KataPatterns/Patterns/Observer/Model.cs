namespace Patterns.Observer
{
    public class Model : Subject
    {
        public string Value { get; private set; }
        public void Refresh()
        {
            Value = "NewValue";
            Notify();
        }
    }
}