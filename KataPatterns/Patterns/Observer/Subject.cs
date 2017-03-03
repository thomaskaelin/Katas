using System.Collections.Generic;

namespace Patterns.Observer
{
    public abstract class Subject
    {
        private readonly List<IObserver> _list;

        protected Subject()
        {
            _list = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            _list.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _list.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _list)
            {
                observer.Update();
            }
        }
    }
}