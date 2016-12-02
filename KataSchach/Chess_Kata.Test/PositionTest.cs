using System;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Chess_Kata.Test
{
    [TestFixture]
    public class PositionTest
    {
        private Position _testee;

        [SetUp]
        public void Setup()
        {
            _testee = new Position(Spalte.E, Zeile._3);
        }

        [Test]
        public void Konstruktor_FülltProperties()
        {
            _testee.Zeile.Should().Be(Zeile._3);
            _testee.Spalte.Should().Be(Spalte.E);
        }

        [Test]
        public void NachOben_MitPositionE3_LiefertE4()
        {
            var result = _testee.NachOben();

            result.Should().Be(new Position(Spalte.E, Zeile._4));
        }

        [Test]
        public void NachOben_LiefertNeuesObjekt()
        {
            var result = _testee.NachOben();

            result.Should().NotBeSameAs(_testee);
        }

        [Test]
        public void NachUnten_MitPositionE3_LiefertE2()
        {
            var result = _testee.NachUnten();

            result.Should().Be(new Position(Spalte.E, Zeile._2));
        }

        [Test]
        public void NachLinks_MitPositionE3_LiefertD3()
        {
            var result = _testee.NachLinks();

            result.Should().Be(new Position(Spalte.D, Zeile._3));
        }

        [Test]
        public void NachRecht_MitPositionE3_LiefertF3()
        {
            var result = _testee.NachRechts();

            result.Should().Be(new Position(Spalte.F, Zeile._3));
        }

        [Test]
        public void Equals_MitGleicherPosition_LiefertTrue()
        {
            var result = _testee.Equals(new Position(Spalte.E, Zeile._3));
            result.Should().BeTrue();
        }

        [Test]
        public void Equals_MitUnterschiedlicherPosition_LiefertFalse()
        {
            var result = _testee.Equals(new Position(Spalte.E, Zeile._4));
            result.Should().BeFalse();
        }

        [Test]
        public void EqualsVonBasisklasse_MitNull_LiefertFalse()
        {
            object input = null;
            var result = _testee.Equals(input);
            result.Should().BeFalse();
        }

        [Test]
        public void EqualsVonBasisklasse_MitString_LiefertFalse()
        {
            string input = "Test";
            var result = _testee.Equals(input);
            result.Should().BeFalse();
        }

        [Test]
        public void EqualsVonBasisklasse_MitGleicherPosition_LiefertTrue()
        {
            object input = new Position(Spalte.E, Zeile._3);
            var result = _testee.Equals(input);
            result.Should().BeTrue();
        }

        [Test]
        public void EqualsVonBasisklasse_MitUnterschiedlicherPosition_LiefertFalse()
        {
            object input = new Position(Spalte.E, Zeile._2);
            var result = _testee.Equals(input);
            result.Should().BeFalse();
        }

        [Test]
        public void GetHashCode_MitVerschiedenenPositionen_LiefertKorrekteWerte()
        {
            var position1 = new Position(Spalte.A, Zeile._1);
            var position2 = new Position(Spalte.A, Zeile._1);
            var position3 = new Position(Spalte.B, Zeile._2);

            var result1 = position1.GetHashCode();
            var result2 = position2.GetHashCode();
            var result3 = position3.GetHashCode();

            result1.Should().Be(result2);
            result1.Should().NotBe(result3);

        }



    }
}