using System;
using System.Collections.Generic;

namespace Chess_Kata
{
    public class BrettBeurteiler
    {
        private Dictionary<Type, IBrettBeurteiler> _figurZuBrettBeurteiler;

        public BrettBeurteiler(Brett brett)
        {
            _figurZuBrettBeurteiler = new Dictionary<Type, IBrettBeurteiler>();

            _figurZuBrettBeurteiler.Add(typeof(Bauer), new BauerBrettBeurteiler(brett));
            _figurZuBrettBeurteiler.Add(typeof(Turm), new TurmBrettBeurteiler(brett));
        }

        public IEnumerable<Position> GibZielpositionenFuerFigur(IFigur figur)
        {
            var zielpositionen = new List<Position>();

            if (_figurZuBrettBeurteiler.ContainsKey(figur.GetType()))
            {
                _figurZuBrettBeurteiler[figur.GetType()].VerarbeiteFigur(figur, zielpositionen);
            }

            return zielpositionen;
        }
    }
}