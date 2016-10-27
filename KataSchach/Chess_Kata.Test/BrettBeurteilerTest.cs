using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Chess_Kata.Test
{
    [TestFixture]
    public class BrettBeurteilerTest
    {
        private BrettBeurteiler _target;
        private Brett _brett;

        [SetUp]
        public void SetUp()
        {
            _brett = new Brett();

            _target = new BrettBeurteiler(_brett);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufB2_LiefertDieKorrektenZielpositionen()
        {
            var figur = SetzeBauer(Spalte.B, Zeile._2, Farbe.Weiss);

            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Count().Should().Be(2);

            var ersteZielposition = result.First();
            PruefeZielposition(ersteZielposition, Spalte.B, Zeile._3);

            var zweiteZielposition = result.Last();
            PruefeZielposition(zweiteZielposition, Spalte.B, Zeile._4);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufC3_LiefertDieKorrektenZielpositionen()
        {
            var figur = SetzeBauer(Spalte.C, Zeile._3, Farbe.Weiss);

            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Count().Should().Be(1);

            var ersteZielposition = result.First();
            PruefeZielposition(ersteZielposition, Spalte.C, Zeile._4);
        }

       [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufC8_LiefertKeineZielpositionen()
        {
            var figur = SetzeBauer(Spalte.C, Zeile._8, Farbe.Weiss);

            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Should().BeEmpty();
        }

       [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufC4_Blockiert_LiefertKeineZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.C, Zeile._4, Farbe.Weiss);
            var bauerSchwarz = SetzeBauer(Spalte.C, Zeile._5, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Should().BeEmpty();
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufG2_Blockiert_LiefertKeineZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.G, Zeile._2, Farbe.Weiss);
            var bauerSchwarz = SetzeBauer(Spalte.G, Zeile._3, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Should().BeEmpty();
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufE5_BesiegbareGegner_LiefertZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.E, Zeile._5, Farbe.Weiss);
            var bauerEinsSchwarz = SetzeBauer(Spalte.D, Zeile._6, Farbe.Schwarz);
            var bauerZweiSchwarz = SetzeBauer(Spalte.F, Zeile._6, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Count().Should().Be(3);

            PruefeZielposition(result.ToList()[0], Spalte.D, Zeile._6);
            PruefeZielposition(result.ToList()[1], Spalte.F, Zeile._6);
            PruefeZielposition(result.ToList()[2], Spalte.E, Zeile._6);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufA4_BesiegbareGegnerAufB5_LiefertZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.A, Zeile._4, Farbe.Weiss);
            var bauerSchwarz = SetzeBauer(Spalte.B, Zeile._5, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Count().Should().Be(2);

            PruefeZielposition(result.ToList()[0], Spalte.B, Zeile._5);
            PruefeZielposition(result.ToList()[1], Spalte.A, Zeile._5);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufH4_BesiegbareGegnerAufG5_LiefertZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.H, Zeile._4, Farbe.Weiss);
            var bauerSchwarz = SetzeBauer(Spalte.G, Zeile._5, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Count().Should().Be(2);

            PruefeZielposition(result.ToList()[0], Spalte.G, Zeile._5);
            PruefeZielposition(result.ToList()[1], Spalte.H, Zeile._5);
        }


        private IFigur SetzeBauer(Spalte spalte, Zeile zeile, Farbe farbe)
        {
            IFigur figur = new Bauer(farbe);
            var position = new Position(spalte, zeile);
            _brett.SetzeFigur(position, figur);
            return figur;
        }

        private static void PruefeZielposition(Position zielposition, Spalte spalte, Zeile zeile)
        {
            zielposition.Zeile.Should().Be(zeile);
            zielposition.Spalte.Should().Be(spalte);
        }

    }
}