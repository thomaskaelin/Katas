using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Kata
{
    public class Brett
    {
        private readonly Dictionary<Zeile, Dictionary<Spalte, IFigur>> _figuren;

        public Brett()
        {
            _figuren = new Dictionary<Zeile, Dictionary<Spalte, IFigur>>();

            foreach (Zeile zeile in Enum.GetValues(typeof(Zeile)))
            {
                _figuren[zeile] = new Dictionary<Spalte, IFigur>();

                foreach (Spalte spalte in Enum.GetValues(typeof(Spalte)))
                {
                    _figuren[zeile][spalte] = null;
                }
            }
        }

        public void SetzeFigur(Position position, IFigur figur)
        {
            _figuren[position.Zeile][position.Spalte] = figur;
        }

        public IFigur HoleFigur(Position position)
        {
            return _figuren[position.Zeile][position.Spalte];
        }

        public Position HolePosition(IFigur figur)
        {
            foreach (var zeile in _figuren.Keys)
            {
                foreach (var spalte in _figuren[zeile].Keys)
                {
                    var eineFigur = _figuren[zeile][spalte];

                    if (eineFigur == figur)
                    {
                        return new Position(spalte, zeile);
                    }
                }
            }

            throw new ArgumentException("Figur befindet sich nicht auf Brett", nameof(figur));
        }
    }
}
