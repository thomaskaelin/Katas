namespace Patterns.Observer
{
    public class Observer : IObserver
    {
        private Model _model;

        public string Value { get; private set; }

        public Observer()
        {
            _model = new Model();
            _model.Attach(this);
        }

        public void Update()
        {
            Value = _model.Value;
        }

        public void Refresh()
        {
            _model.Refresh();
        }
    }
}