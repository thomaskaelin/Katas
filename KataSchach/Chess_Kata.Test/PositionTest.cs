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

            result.Spalte.Should().Be(Spalte.E);
            result.Zeile.Should().Be(Zeile._4);
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

            result.Spalte.Should().Be(Spalte.E);
            result.Zeile.Should().Be(Zeile._2);
        }

        [Test]
        public void NachLinks_MitPositionE3_LiefertD3()
        {
            var result = _testee.NachLinks();

            result.Spalte.Should().Be(Spalte.D);
            result.Zeile.Should().Be(Zeile._3);
        }

        [Test]
        public void NachRecht_MitPositionE3_LiefertF3()
        {
            var result = _testee.NachRechts();

            result.Spalte.Should().Be(Spalte.F);
            result.Zeile.Should().Be(Zeile._3);
        }



    }
}