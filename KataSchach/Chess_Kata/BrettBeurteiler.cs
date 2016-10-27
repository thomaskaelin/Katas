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
            var zielpositionen = new List<Position>();

            if (!IstFigurAufLetzterZeile(figur))
            {
                VerarbeiteFeldEinsOben(figur, zielpositionen);
                VerarbeiteFeldZweiOben(figur, zielpositionen);
                VerarbeiteFeldObenLinks(figur, zielpositionen);
                VerarbeiteFeldObenRechts(figur, zielpositionen);
            }

            return zielpositionen;
        }

        private Position HolePosition(IFigur figur)
        {
            return _brett.HolePosition(figur);
        }

        private bool IstFigurAufLetzterZeile(IFigur figur)
        {
            return HolePosition(figur).Zeile == Zeile._8;
        }

        private bool IstFigurAufStartZeile(IFigur figur)
        {
            return HolePosition(figur).Zeile == Zeile._2;
        }

        private bool IstErsteSpalte(IFigur figur)
        {
            return HolePosition(figur).Spalte == Spalte.A;
        }

        private bool IstFigurInLetzterSpalte(IFigur figur)
        {
            return HolePosition(figur).Spalte == Spalte.H;
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

        private void VerarbeiteFeldEinsOben(IFigur figur, ICollection<Position> zielpositionen)
        {
            var position = HolePosition(figur);
            var positionEineZeileHoch = position.NachOben();

            if (IstFeldBelegt(positionEineZeileHoch))
            {
                return;
            }

            zielpositionen.Add(positionEineZeileHoch);
        }

        private void VerarbeiteFeldZweiOben(IFigur figur, ICollection<Position> zielpositionen)
        {
            if (!IstFigurAufStartZeile(figur))
            {
                return;
            }

            var position = HolePosition(figur);
            var positionEineZeileHoch = position.NachOben();
            var positionzweiZeilenHoch = positionEineZeileHoch.NachOben();

            if (IstFeldBelegt(positionEineZeileHoch))
            {
                return;
            }

            if (IstFeldBelegt(positionzweiZeilenHoch))
            {
                return;
            }
            
            zielpositionen.Add(positionzweiZeilenHoch);
        }

        private void VerarbeiteFeldObenLinks(IFigur figur, ICollection<Position> zielpositionen)
        {
            if (IstErsteSpalte(figur))
                return;

            var position = HolePosition(figur);
            var positionEineHochEineLinks = position.NachLinks().NachOben();

            if (!IstFeldVonGegnerBelegt(positionEineHochEineLinks, figur))
            {
                return;
            }

            zielpositionen.Add(positionEineHochEineLinks);
        }

        private void VerarbeiteFeldObenRechts(IFigur figur, ICollection<Position> zielpositionen)
        {
            if (IstFigurInLetzterSpalte(figur))
                return;

            var position = HolePosition(figur);
            var positionEineHochEineRechts = position.NachRechts().NachOben();

            if (!IstFeldVonGegnerBelegt(positionEineHochEineRechts, figur))
            {
                return;
            }

            zielpositionen.Add(positionEineHochEineRechts);
        }
    }
}