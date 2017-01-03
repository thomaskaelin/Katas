using Tennis.Contract;

namespace Tennis.StateMachine
{
    public class TennisStateMachine :StateMachine<TennisState, TennisEvent>
    {
        public TennisStateMachine()
        {
            StateMachine<TennisState, TennisEvent> tennisStateMachine = new StateMachine<TennisState, TennisEvent>();
        }
        
    }
}