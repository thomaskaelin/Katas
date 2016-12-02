using System;
using System.Collections.Generic;

namespace Chess_Kata
{
    public class Brett
    {
        private readonly Dictionary<Position, IFigur> _figuren;

        public Brett()
        {
            _figuren = new Dictionary<Position, IFigur>();

            foreach (Spalte spalte in Enum.GetValues(typeof(Spalte)))
            {
                foreach (Zeile zeile in Enum.GetValues(typeof(Zeile)))
                {
                    var position = new Position(spalte, zeile);
                    _figuren[position] = null;
                }
            }
        }

        public void SetzeFigur(Position position, IFigur figur)
        {
            _figuren[position] = figur;
        }

        public IFigur HoleFigur(Position position)
        {
            return _figuren[position];
        }

        public Position HolePosition(IFigur figur)
        {
            foreach (var kvp in _figuren)
            {
                if (kvp.Value == figur)
                {
                    var positionDerFigur = kvp.Key;
                    return new Position(positionDerFigur.Spalte, positionDerFigur.Zeile);
                }
            }

            throw new ArgumentException("Figur befindet sich nicht auf Brett", nameof(figur));
        }
    }
}
