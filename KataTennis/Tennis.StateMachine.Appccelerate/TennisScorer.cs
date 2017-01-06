using System;
using Appccelerate.StateMachine;
using Appccelerate.StateMachine.Extensions;
using Appccelerate.StateMachine.Machine;
using Tennis.Contract;

namespace Tennis.StateMachine.Appccelerate
{
    public class TennisScorer : ExtensionBase<TennisState, TennisEvent>, ITennisScorer
    {
        private readonly PassiveStateMachine<TennisState, TennisEvent> _stateMachine;

        private TennisState _actualState;

        public TennisScorer()
        {
            _stateMachine = new PassiveStateMachine<TennisState, TennisEvent>();

            _stateMachine.In(TennisState._0to0).On(TennisEvent.AScores).Goto(TennisState._15to0);
            _stateMachine.In(TennisState._0to0).On(TennisEvent.BScores).Goto(TennisState._0to15);

            _stateMachine.In(TennisState._0to15).On(TennisEvent.AScores).Goto(TennisState._15to15);
            _stateMachine.In(TennisState._0to15).On(TennisEvent.BScores).Goto(TennisState._0to30);

            _stateMachine.In(TennisState._0to30).On(TennisEvent.AScores).Goto(TennisState._15to30);
            _stateMachine.In(TennisState._0to30).On(TennisEvent.BScores).Goto(TennisState._0to40);

            _stateMachine.In(TennisState._0to40).On(TennisEvent.AScores).Goto(TennisState._15to40);
            _stateMachine.In(TennisState._0to40).On(TennisEvent.BScores).Goto(TennisState.GameB);

            _stateMachine.In(TennisState._15to0).On(TennisEvent.AScores).Goto(TennisState._30to0);
            _stateMachine.In(TennisState._15to0).On(TennisEvent.BScores).Goto(TennisState._15to15);

            _stateMachine.In(TennisState._15to15).On(TennisEvent.AScores).Goto(TennisState._30to15);
            _stateMachine.In(TennisState._15to15).On(TennisEvent.BScores).Goto(TennisState._15to30);

            _stateMachine.In(TennisState._15to30).On(TennisEvent.AScores).Goto(TennisState._30to30);
            _stateMachine.In(TennisState._15to30).On(TennisEvent.BScores).Goto(TennisState._15to40);

            _stateMachine.In(TennisState._15to40).On(TennisEvent.AScores).Goto(TennisState._30to40);
            _stateMachine.In(TennisState._15to40).On(TennisEvent.BScores).Goto(TennisState.GameB);

            _stateMachine.In(TennisState._30to0).On(TennisEvent.AScores).Goto(TennisState._40to0);
            _stateMachine.In(TennisState._30to0).On(TennisEvent.BScores).Goto(TennisState._30to15);

            _stateMachine.In(TennisState._30to15).On(TennisEvent.AScores).Goto(TennisState._40to15);
            _stateMachine.In(TennisState._30to15).On(TennisEvent.BScores).Goto(TennisState._30to30);

            _stateMachine.In(TennisState._30to30).On(TennisEvent.AScores).Goto(TennisState._40to30);
            _stateMachine.In(TennisState._30to30).On(TennisEvent.BScores).Goto(TennisState._30to40);

            _stateMachine.In(TennisState._30to40).On(TennisEvent.AScores).Goto(TennisState.Deuce);
            _stateMachine.In(TennisState._30to40).On(TennisEvent.BScores).Goto(TennisState.GameB);

            _stateMachine.In(TennisState._40to0).On(TennisEvent.AScores).Goto(TennisState.GameA);
            _stateMachine.In(TennisState._40to0).On(TennisEvent.BScores).Goto(TennisState._40to15);

            _stateMachine.In(TennisState._40to15).On(TennisEvent.AScores).Goto(TennisState.GameA);
            _stateMachine.In(TennisState._40to15).On(TennisEvent.BScores).Goto(TennisState._40to30);

            _stateMachine.In(TennisState._40to30).On(TennisEvent.AScores).Goto(TennisState.GameA);
            _stateMachine.In(TennisState._40to30).On(TennisEvent.BScores).Goto(TennisState.Deuce);

            _stateMachine.In(TennisState.Deuce).On(TennisEvent.AScores).Goto(TennisState.AdvantageA);
            _stateMachine.In(TennisState.Deuce).On(TennisEvent.BScores).Goto(TennisState.AdvantageB);

            _stateMachine.In(TennisState.AdvantageA).On(TennisEvent.AScores).Goto(TennisState.GameA);
            _stateMachine.In(TennisState.AdvantageA).On(TennisEvent.BScores).Goto(TennisState.Deuce);

            _stateMachine.In(TennisState.AdvantageB).On(TennisEvent.AScores).Goto(TennisState.Deuce);
            _stateMachine.In(TennisState.AdvantageB).On(TennisEvent.BScores).Goto(TennisState.GameB);

            _stateMachine.Initialize(TennisState._0to0);
            _stateMachine.AddExtension(this);

           _stateMachine.TransitionDeclined += (sender, args) => { throw new InvalidOperationException(); };
           _stateMachine.TransitionExceptionThrown += (sender, args) => { throw new InvalidOperationException(); };

            _stateMachine.Start();
        }

        public override void SwitchedState(IStateMachineInformation<TennisState, TennisEvent> stateMachine, IState<TennisState, TennisEvent> oldState, IState<TennisState, TennisEvent> newState)
        {
            _actualState = newState.Id;
        }

        public string GetScore()
        {
            return _actualState.AsString();
        }

        public void PlayerAScores()
        {
            _stateMachine.Fire(TennisEvent.AScores);
        }

        public void PlayerBScores()
        {
            _stateMachine.Fire(TennisEvent.BScores);
        }
    }
}