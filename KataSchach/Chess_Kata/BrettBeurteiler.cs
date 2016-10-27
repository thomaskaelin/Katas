using System.Collections;
using System.Collections.Generic;

namespace Chess_Kata
{
    public class BrettBeurteiler 
    {
        private readonly Brett _brett;

        public BrettBeurteiler(Brett brett)
        {
            _brett = brett;
        }

        public IEnumerable<Position> GibZielpositionenFuerFigur(IFigur figur)
        {
            var positionVonFigur = _brett.HolePosition(figur);
            var zielpositionen = new List<Position>();
            var zeile = positionVonFigur.Zeile;
            var spalte = positionVonFigur.Spalte;

            if (zeile != Zeile._8)
            {
                var eineZeileHoch = zeile.Erhoehen();

                if (spalte != Spalte.A)
                {
                    var eineSpalteLinks = spalte.Verringern();

                    var positionEineHochLinks = new Position(eineSpalteLinks, eineZeileHoch);
                    if (IstFeldVonGegnerBelegt(positionEineHochLinks, figur))
                    {
                        zielpositionen.Add(positionEineHochLinks);
                    }
                }

                if (spalte != Spalte.H)
                {
                    var eineSpalteRechts = spalte.Erhoehen();

                    var positionEineHochRechts = new Position(eineSpalteRechts, eineZeileHoch);
                    if (IstFeldVonGegnerBelegt(positionEineHochRechts, figur))
                    {
                        zielpositionen.Add(positionEineHochRechts);
                    }

                }

                
                

                var positionEineZeileHoch = new Position(positionVonFigur.Spalte, eineZeileHoch);
                if (IstFeldBelegt(positionEineZeileHoch))
                {
                    return zielpositionen;
                    
                }
                zielpositionen.Add(positionEineZeileHoch);

                if (zeile == Zeile._2)
                {
                    var zweiZeilenHoch = eineZeileHoch.Erhoehen();
                    var positionZweiZeilenHoch = new Position(positionVonFigur.Spalte, zweiZeilenHoch);
                    if (!IstFeldBelegt(positionZweiZeilenHoch))
                    {
                        zielpositionen.Add(positionZweiZeilenHoch);
                    }
                }
            }

            return zielpositionen;

        }

        private bool IstFeldBelegt(Position position)
        {
            return _brett.HoleFigur(position) != null;
        }

        private bool IstFeldVonGegnerBelegt(Position position, IFigur meineFigur)
        {
            if (!IstFeldBelegt(position))
            {
                return false;
            }
            var figur = _brett.HoleFigur(position);
            return figur.Farbe != meineFigur.Farbe;
        }

        
    }
}