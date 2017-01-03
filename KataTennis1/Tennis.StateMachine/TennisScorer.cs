using Tennis.Contract;

namespace Tennis.StateMachine
{
    public class TennisScorer : ITennisScorer
    {
        private readonly TennisStateMachine _stateMachine;
        public TennisScorer()
        {
            _stateMachine = new TennisStateMachine();
            _stateMachine.SetInitial(TennisState._0to0);
            _stateMachine.AddTransition(TennisState._0to0, TennisEvent.AScores, TennisState._15to0);
            _stateMachine.AddTransition(TennisState._0to0, TennisEvent.BScores, TennisState._0to15);

            _stateMachine.AddTransition(TennisState._0to15, TennisEvent.AScores, TennisState._15to15);
            _stateMachine.AddTransition(TennisState._0to15, TennisEvent.BScores, TennisState._0to30);

            _stateMachine.AddTransition(TennisState._0to30, TennisEvent.AScores, TennisState._15to30);
            _stateMachine.AddTransition(TennisState._0to30, TennisEvent.BScores, TennisState._0to40);

            _stateMachine.AddTransition(TennisState._0to40, TennisEvent.AScores, TennisState._15to40);
            _stateMachine.AddTransition(TennisState._0to40, TennisEvent.BScores, TennisState.GameB);

            _stateMachine.AddTransition(TennisState._15to0, TennisEvent.AScores, TennisState._30to0);
            _stateMachine.AddTransition(TennisState._15to0, TennisEvent.BScores, TennisState._15to15);

            _stateMachine.AddTransition(TennisState._15to15, TennisEvent.AScores, TennisState._30to15);
            _stateMachine.AddTransition(TennisState._15to15, TennisEvent.BScores, TennisState._15to30);

            _stateMachine.AddTransition(TennisState._15to30, TennisEvent.AScores, TennisState._30to30);
            _stateMachine.AddTransition(TennisState._15to30, TennisEvent.BScores, TennisState._15to40);

            _stateMachine.AddTransition(TennisState._15to40, TennisEvent.AScores, TennisState._30to40);
            _stateMachine.AddTransition(TennisState._15to40, TennisEvent.BScores, TennisState.GameB);

            _stateMachine.AddTransition(TennisState._30to0, TennisEvent.AScores, TennisState._40to0);
            _stateMachine.AddTransition(TennisState._30to0, TennisEvent.BScores, TennisState._30to15);

            _stateMachine.AddTransition(TennisState._30to15, TennisEvent.AScores, TennisState._40to15);
            _stateMachine.AddTransition(TennisState._30to15, TennisEvent.BScores, TennisState._30to30);

            _stateMachine.AddTransition(TennisState._30to30, TennisEvent.AScores, TennisState._40to30);
            _stateMachine.AddTransition(TennisState._30to30, TennisEvent.BScores, TennisState._30to40);

            _stateMachine.AddTransition(TennisState._30to40, TennisEvent.AScores, TennisState._40to40);
            _stateMachine.AddTransition(TennisState._30to40, TennisEvent.BScores, TennisState.GameB);

            _stateMachine.AddTransition(TennisState._40to0, TennisEvent.AScores, TennisState.GameA);
            _stateMachine.AddTransition(TennisState._40to0, TennisEvent.BScores, TennisState._40to15);

            _stateMachine.AddTransition(TennisState._40to15, TennisEvent.AScores, TennisState.GameA);
            _stateMachine.AddTransition(TennisState._40to15, TennisEvent.BScores, TennisState._40to30);

            _stateMachine.AddTransition(TennisState._40to30, TennisEvent.AScores, TennisState.GameA);
            _stateMachine.AddTransition(TennisState._40to30, TennisEvent.BScores, TennisState._40to40);

            _stateMachine.AddTransition(TennisState._40to40, TennisEvent.AScores, TennisState.AdvantageA);
            _stateMachine.AddTransition(TennisState._40to40, TennisEvent.BScores, TennisState.AdvantageB);

            _stateMachine.AddTransition(TennisState.AdvantageA, TennisEvent.AScores, TennisState.GameA);
            _stateMachine.AddTransition(TennisState.AdvantageA, TennisEvent.BScores, TennisState._40to40);

            _stateMachine.AddTransition(TennisState.AdvantageB, TennisEvent.AScores, TennisState._40to40);
            _stateMachine.AddTransition(TennisState.AdvantageB, TennisEvent.BScores, TennisState.GameB);
        }

        public string GetScore()
        {
            return _stateMachine.ActualState.AsString();
        }

        public void PlayerAScores()
        {
            _stateMachine.DoEvent(TennisEvent.AScores);
        }

        public void PlayerBScores()
        {
            _stateMachine.DoEvent(TennisEvent.BScores);
        }
    }
}
