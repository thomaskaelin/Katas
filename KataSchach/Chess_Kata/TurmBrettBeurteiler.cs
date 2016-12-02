using System;
using System.Collections.Generic;

namespace Chess_Kata
{
    public class TurmBrettBeurteiler : IBrettBeurteiler
    {
        private readonly Brett _brett;

        public TurmBrettBeurteiler(Brett brett)
        {
            _brett = brett;
        }

        public void VerarbeiteFigur(IFigur figur, List<Position> zielpositionen)
        {

            Bewegungen(
                figur, 
                zielpositionen, 
                aktuellePosition => !aktuellePosition.Spalte.IstErsteSpalte(),
                aktuellePosition => aktuellePosition.NachLinks());

            Bewegungen(
                figur, 
                zielpositionen, 
                aktuellePosition => !aktuellePosition.Spalte.IstLetzteSpalte(),
                aktuellePosition => aktuellePosition.NachRechts());

            Bewegungen(
                figur, 
                zielpositionen, 
                aktuellePosition => !aktuellePosition.Zeile.IstErsteZeile(),
                aktuellePosition => aktuellePosition.NachUnten());

            Bewegungen(
                figur, 
                zielpositionen, 
                aktuellePosition => !aktuellePosition.Zeile.IstLetzteZeile(),
                aktuellePosition => aktuellePosition.NachOben());

        }

        private void Bewegungen(
            IFigur figur, 
            ICollection<Position> zielpositionen, 
            Func<Position, bool> abbruchbedingung,
            Func<Position, Position> bestimmeNeuePosition)
        {
            var position = _brett.HolePosition(figur);

            while (abbruchbedingung(position))
            {
                var neuePosition = bestimmeNeuePosition(position);

                if (IstPositionBelegt(neuePosition))
                {
                    if (IstPositionBelegtMitGegner(neuePosition, figur))
                    {
                        zielpositionen.Add(neuePosition);
                    }

                    break;
                }

                zielpositionen.Add(neuePosition);
                position = neuePosition;
            }
        }

        private bool IstPositionBelegtMitGegner(Position position, IFigur figur)
        {
            return _brett.HoleFigur(position).Farbe != figur.Farbe;
        }

        private bool IstPositionBelegt(Position position)
        {
            return _brett.HoleFigur(position) != null;
        }
    }
}
