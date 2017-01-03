using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.StateMachine
{
    public class TennisScorer : ITennisScorer
    {
        private readonly StateMachine _stateMachine;
        public TennisScorer()
        {
            _stateMachine = new StateMachine();
            _stateMachine.SetInitial(State._0to0);
            _stateMachine.AddTransition(State._0to0, Event.AScores, State._15to0);
            _stateMachine.AddTransition(State._0to0, Event.BScores, State._0to15);

            _stateMachine.AddTransition(State._0to15, Event.AScores, State._15to15);
            _stateMachine.AddTransition(State._0to15, Event.BScores, State._0to30);

            _stateMachine.AddTransition(State._0to30, Event.AScores, State._15to30);
            _stateMachine.AddTransition(State._0to30, Event.BScores, State._0to40);

            _stateMachine.AddTransition(State._0to40, Event.AScores, State._15to40);
            _stateMachine.AddTransition(State._0to40, Event.BScores, State.GameB);

            _stateMachine.AddTransition(State._15to0, Event.AScores, State._30to0);
            _stateMachine.AddTransition(State._15to0, Event.BScores, State._15to15);

            _stateMachine.AddTransition(State._15to15, Event.AScores, State._30to15);
            _stateMachine.AddTransition(State._15to15, Event.BScores, State._15to30);

            _stateMachine.AddTransition(State._15to30, Event.AScores, State._30to30);
            _stateMachine.AddTransition(State._15to30, Event.BScores, State._15to40);

            _stateMachine.AddTransition(State._15to40, Event.AScores, State._30to40);
            _stateMachine.AddTransition(State._15to40, Event.BScores, State.GameB);

            _stateMachine.AddTransition(State._30to0, Event.AScores, State._40to0);
            _stateMachine.AddTransition(State._30to0, Event.BScores, State._30to15);

            _stateMachine.AddTransition(State._30to15, Event.AScores, State._40to15);
            _stateMachine.AddTransition(State._30to15, Event.BScores, State._30to30);

            _stateMachine.AddTransition(State._30to30, Event.AScores, State._40to30);
            _stateMachine.AddTransition(State._30to30, Event.BScores, State._30to40);

            _stateMachine.AddTransition(State._30to40, Event.AScores, State._40to40);
            _stateMachine.AddTransition(State._30to40, Event.BScores, State.GameB);

            _stateMachine.AddTransition(State._40to0, Event.AScores, State.GameA);
            _stateMachine.AddTransition(State._40to0, Event.BScores, State._40to15);

            _stateMachine.AddTransition(State._40to15, Event.AScores, State.GameA);
            _stateMachine.AddTransition(State._40to15, Event.BScores, State._40to30);

            _stateMachine.AddTransition(State._40to30, Event.AScores, State.GameA);
            _stateMachine.AddTransition(State._40to30, Event.BScores, State._40to40);

            _stateMachine.AddTransition(State._40to40, Event.AScores, State.AdvantageA);
            _stateMachine.AddTransition(State._40to40, Event.BScores, State.AdvantageB);

            _stateMachine.AddTransition(State.AdvantageA, Event.AScores, State.GameA);
            _stateMachine.AddTransition(State.AdvantageA, Event.BScores, State._40to40);

            _stateMachine.AddTransition(State.AdvantageB, Event.AScores, State._40to40);
            _stateMachine.AddTransition(State.AdvantageB, Event.BScores, State.GameB);






        }
        public string GetScore()
        {
            switch (_stateMachine.ActualState)
            {
                case State._0to0:
                    return "0-0";
                case State._15to0:
                    return "15-0";
                case State._0to15:
                    return "0-15";
                case State._0to30:
                    return "0-30";
                case State._0to40:
                    return "0-40";
                case State._15to15:
                    return "15-15";
                case State._15to30:
                    return "15-30";
                case State._15to40:
                    return "15-40";
                case State._30to0:
                    return "30-0";
                case State._30to15:
                    return "30-15";
                case State._30to30:
                    return "30-30";
                case State._30to40:
                    return "30-40";
                case State._40to0:
                    return "40-0";
                case State._40to15:
                    return "40-15";
                case State._40to30:
                    return "40-30";
                case State._40to40:
                    return "40-40";
                case State.AdvantageA:
                    return "AdvantageA";
                case State.AdvantageB:
                    return "AdvantageB";
                case State.GameA:
                    return "GameA";
                case State.GameB:
                    return "GameB";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PlayerAScores()
        {
            _stateMachine.DoEvent(Event.AScores);
        }

        public void PlayerBScores()
        {
            _stateMachine.DoEvent(Event.BScores);
        }
    }
}
