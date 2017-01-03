using System;

namespace Tennis.Contract
{
    public static class TennisStateExtensions
    {
        public static string AsString(this TennisState input)
        {
            switch (input)
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
    }
}