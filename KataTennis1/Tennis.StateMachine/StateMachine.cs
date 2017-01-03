using System;
using System.Collections.Generic;

namespace Tennis.StateMachine
{
    public class StateMachine <TState, TEvent>
    {
        public TState ActualState { get; private set; }

        private readonly Dictionary<TState, Dictionary<TEvent, TState>> _transitions = new Dictionary<TState, Dictionary<TEvent, TState>>();

        public void AddTransition(TState from, TEvent with, TState to)
        {
            if (!_transitions.ContainsKey(from))
            {
                _transitions.Add(from, new Dictionary<TEvent, TState>());    
            }
            if (_transitions[from].ContainsKey(with))
            {
                throw new InvalidOperationException();
            }

            _transitions[from][with] = to;
        }

        public void SetInitial(TState initial)
        {
            ActualState = initial;
        }

        public void DoEvent(TEvent @event)
        {
            if (!_transitions.ContainsKey(ActualState) || !_transitions[ActualState].ContainsKey(@event))
            {
                throw new InvalidOperationException();
            }
            ActualState = _transitions[ActualState][@event];
        }
    }
}