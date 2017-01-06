using System;

namespace Tennis.Normal
{
    public enum Point
    {
        _0 = 0,
        _15,
        _30,
        _40,
        Game,
        Advantage
    }

    public static class PointExtensions
    {
        public static string AsString(this Point point)
        {
            switch (point)
            {
                case Point._0:
                    return "0";
                case Point._15:
                    return "15";
                case Point._30:
                    return "30";
                case Point._40:
                    return "40";
                case Point.Advantage:
                    return "Advantage";
                case Point.Game:
                    return "Game";
                default:
                    throw new ArgumentOutOfRangeException(nameof(point), point, null);
            }
        }
    }
}