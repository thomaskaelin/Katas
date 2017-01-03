using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (_stateMachine.ActualState)
            {
                case TennisState._0to0:
                    return "0-0";
                case TennisState._15to0:
                    return "15-0";
                case TennisState._0to15:
                    return "0-15";
                case TennisState._0to30:
                    return "0-30";
                case TennisState._0to40:
                    return "0-40";
                case TennisState._15to15:
                    return "15-15";
                case TennisState._15to30:
                    return "15-30";
                case TennisState._15to40:
                    return "15-40";
                case TennisState._30to0:
                    return "30-0";
                case TennisState._30to15:
                    return "30-15";
                case TennisState._30to30:
                    return "30-30";
                case TennisState._30to40:
                    return "30-40";
                case TennisState._40to0:
                    return "40-0";
                case TennisState._40to15:
                    return "40-15";
                case TennisState._40to30:
                    return "40-30";
                case TennisState._40to40:
                    return "40-40";
                case TennisState.AdvantageA:
                    return "AdvantageA";
                case TennisState.AdvantageB:
                    return "AdvantageB";
                case TennisState.GameA:
                    return "GameA";
                case TennisState.GameB:
                    return "GameB";
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
