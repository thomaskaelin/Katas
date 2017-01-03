using System;
using System.Collections.Generic;

namespace Tennis.StateMachine
{
    public class StateMachine
    {
        public State ActualState { get; private set; }

        private readonly Dictionary<State, Dictionary<Event, State>> _transitions = new Dictionary<State, Dictionary<Event, State>>();

        public void AddTransition(State from, Event with, State to)
        {
            if (!_transitions.ContainsKey(from))
            {
                _transitions.Add(from, new Dictionary<Event, State>());    
            }
            if (_transitions[from].ContainsKey(with))
            {
                throw new InvalidOperationException();
            }

            _transitions[from][with] = to;
        }

        public void SetInitial(State initial)
        {
            ActualState = initial;
        }

        public void DoEvent(Event @event)
        {
            if (!_transitions.ContainsKey(ActualState) || !_transitions[ActualState].ContainsKey(@event))
            {
                throw new InvalidOperationException();
            }
            ActualState = _transitions[ActualState][@event];
        }
    }
}