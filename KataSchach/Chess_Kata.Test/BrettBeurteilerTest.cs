using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable UnusedVariable

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

            PruefeZielposition(result, Spalte.B, Zeile._3);
            PruefeZielposition(result, Spalte.B, Zeile._4);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufC3_LiefertDieKorrektenZielpositionen()
        {
            var figur = SetzeBauer(Spalte.C, Zeile._3, Farbe.Weiss);

            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Count().Should().Be(1);

            PruefeZielposition(result, Spalte.C, Zeile._4);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufC8_LiefertKeineZielpositionen()
        {
            var figur = SetzeBauer(Spalte.C, Zeile._8, Farbe.Weiss);

            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Should().BeEmpty();
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufF2_BlockierenderGegnerAufF4_LiefertKeineZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.F, Zeile._2, Farbe.Weiss);
            var bauerSchwarz = SetzeBauer(Spalte.F, Zeile._4, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Count().Should().Be(1);
            PruefeZielposition(result, Spalte.F, Zeile._3);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufC4_BlockierenderGegnerAufC5_LiefertKeineZielpositionen()
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

            PruefeZielposition(result, Spalte.E, Zeile._6);
            PruefeZielposition(result, Spalte.D, Zeile._6);
            PruefeZielposition(result, Spalte.F, Zeile._6);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufA4_BesiegbareGegnerAufB5_LiefertZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.A, Zeile._4, Farbe.Weiss);
            var bauerSchwarz = SetzeBauer(Spalte.B, Zeile._5, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Count().Should().Be(2);

            PruefeZielposition(result, Spalte.A, Zeile._5);
            PruefeZielposition(result, Spalte.B, Zeile._5);
        }

        [Test]
        public void GibZielpositionenFuerFigur_BauerStehtAufH4_BesiegbareGegnerAufG5_LiefertZielpositionen()
        {
            var bauerWeiss = SetzeBauer(Spalte.H, Zeile._4, Farbe.Weiss);
            var bauerSchwarz = SetzeBauer(Spalte.G, Zeile._5, Farbe.Schwarz);

            var result = _target.GibZielpositionenFuerFigur(bauerWeiss);

            result.Count().Should().Be(2);

            PruefeZielposition(result, Spalte.H, Zeile._5);
            PruefeZielposition(result, Spalte.G, Zeile._5);
        }

        [Test]
        public void GibZielpositionenFuerFigur_TurmStehtAufE4_LiefertZielpositionen()
        {
            var figur = SetzeTurm(Spalte.A, Zeile._8, Farbe.Weiss);
            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Count().Should().Be(14);

            PruefeZielposition(result, Spalte.A, Zeile._4);
            PruefeZielposition(result, Spalte.B, Zeile._4);
            PruefeZielposition(result, Spalte.C, Zeile._4);
            PruefeZielposition(result, Spalte.D, Zeile._4);
            PruefeZielposition(result, Spalte.F, Zeile._4);
            PruefeZielposition(result, Spalte.G, Zeile._4);
            PruefeZielposition(result, Spalte.H, Zeile._4);

            PruefeZielposition(result, Spalte.E, Zeile._1);
            PruefeZielposition(result, Spalte.E, Zeile._2);
            PruefeZielposition(result, Spalte.E, Zeile._3);
            PruefeZielposition(result, Spalte.E, Zeile._5);
            PruefeZielposition(result, Spalte.E, Zeile._6);
            PruefeZielposition(result, Spalte.E, Zeile._7);
            PruefeZielposition(result, Spalte.E, Zeile._8);

        }

        [Test]
        public void GibZielpositionenFuerFigur_TurmStehtAufA8_LiefertZielpositionen()
        {
            var figur = SetzeTurm(Spalte.A, Zeile._8, Farbe.Weiss);
            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Count().Should().Be(14);
            
            PruefeZielposition(result, Spalte.B, Zeile._8);
            PruefeZielposition(result, Spalte.C, Zeile._8);
            PruefeZielposition(result, Spalte.D, Zeile._8);
            PruefeZielposition(result, Spalte.E, Zeile._8);
            PruefeZielposition(result, Spalte.F, Zeile._8);
            PruefeZielposition(result, Spalte.G, Zeile._8);
            PruefeZielposition(result, Spalte.H, Zeile._8);

            PruefeZielposition(result, Spalte.A, Zeile._1);
            PruefeZielposition(result, Spalte.A, Zeile._2);
            PruefeZielposition(result, Spalte.A, Zeile._3);
            PruefeZielposition(result, Spalte.A, Zeile._4);
            PruefeZielposition(result, Spalte.A, Zeile._5);
            PruefeZielposition(result, Spalte.A, Zeile._6);
            PruefeZielposition(result, Spalte.A, Zeile._7);
        }

        [Test]
        public void GibZielpositionenFuerFigur_TurmStehtAufH1_LiefertZielpositionen()
        {
            var figur = SetzeTurm(Spalte.H, Zeile._1, Farbe.Weiss);
            var result = _target.GibZielpositionenFuerFigur(figur);

            result.Count().Should().Be(14);

            PruefeZielposition(result, Spalte.A, Zeile._1);
            PruefeZielposition(result, Spalte.B, Zeile._1);
            PruefeZielposition(result, Spalte.C, Zeile._1);
            PruefeZielposition(result, Spalte.D, Zeile._1);
            PruefeZielposition(result, Spalte.E, Zeile._1);
            PruefeZielposition(result, Spalte.F, Zeile._1);
            PruefeZielposition(result, Spalte.G, Zeile._1);

            PruefeZielposition(result, Spalte.H, Zeile._2);
            PruefeZielposition(result, Spalte.H, Zeile._3);
            PruefeZielposition(result, Spalte.H, Zeile._4);
            PruefeZielposition(result, Spalte.H, Zeile._5);
            PruefeZielposition(result, Spalte.H, Zeile._6);
            PruefeZielposition(result, Spalte.H, Zeile._7);
            PruefeZielposition(result, Spalte.H, Zeile._8);
        }

        [Test]
        public void GibZielPositionenFuerFigur_TurmStehtAufD4_BlockiertAufAllenSeiten()
        {
            var startFigur = SetzeTurm(Spalte.D, Zeile._4, Farbe.Weiss);
            var gegnerFigurEins = SetzeBauer(Spalte.D, Zeile._5, Farbe.Schwarz);
            var gegnerFigurZwei = SetzeTurm(Spalte.B, Zeile._4, Farbe.Schwarz);
            var freundFigurEins = SetzeBauer(Spalte.E, Zeile._4, Farbe.Weiss);
            var freundFigurZwei = SetzeTurm(Spalte.D, Zeile._2, Farbe.Weiss);

            var result = _target.GibZielpositionenFuerFigur(startFigur);

            result.Count().Should().Be(4);

            PruefeZielposition(result, Spalte.B, Zeile._4);
            PruefeZielposition(result, Spalte.C, Zeile._4);
            PruefeZielposition(result, Spalte.D, Zeile._3);
            PruefeZielposition(result, Spalte.D, Zeile._5);
        }

        private IFigur SetzeTurm(Spalte spalte, Zeile zeile, Farbe farbe)
        {
            IFigur figur = new Turm(farbe);
            var position = new Position(spalte, zeile);
            _brett.SetzeFigur(position, figur);
            return figur;
        }

        private IFigur SetzeBauer(Spalte spalte, Zeile zeile, Farbe farbe)
        {
            IFigur figur = new Bauer(farbe);
            var position = new Position(spalte, zeile);
            _brett.SetzeFigur(position, figur);
            return figur;
        }

        private static void PruefeZielposition(IEnumerable<Position> zielpositionen, Spalte spalte, Zeile zeile)
        {
            var passendeZielpositionen = zielpositionen.Where(position => position.Spalte == spalte && position.Zeile == zeile);
            passendeZielpositionen.Count().Should().Be(1);
        }
    }
}