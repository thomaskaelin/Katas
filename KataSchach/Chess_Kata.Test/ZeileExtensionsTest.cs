using System;
using FluentAssertions;
using NUnit.Framework;

namespace Chess_Kata.Test
{
    [TestFixture]
    public class ZeileExtensionsTest
    {

        [Test]
        public void Erhoehen_Zeile3_LiefertZeile4()
        {
            var result = Zeile._3.Erhoehen();
            result.Should().Be(Zeile._4);
        }

        [Test]
        public void Erhöhen_Zeile8_LieferException()
        {
            Action action = () => { Zeile._8.Erhoehen(); };
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void Verringern_Zeile4_LiefertZeile3()
        {
            var result = Zeile._4.Verringern();
            result.Should().Be(Zeile._3);
        }

        [Test]
        public void Verringern_Zeile1_LiefertException()
        {
            Action action = () => { Zeile._1.Verringern(); };
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void IstLetzteZeile_Zeile8_LiefertTrue()
        {
            var result = Zeile._8.IstLetzteZeile();
            result.Should().BeTrue();
        }

        [Test]
        public void IstLetzteZeile_Zeile4_LiefertFalse()
        {
            var result = Zeile._4.IstLetzteZeile();
            result.Should().BeFalse();
        }

        [Test]
        public void IstErsteZeile_Zeile1_LiefertTrue()
        {
            var result = Zeile._1.IstErsteZeile();
            result.Should().BeTrue();
        }

        [Test]
        public void IstErsteZeile_Zeile4_LiefertFalse()
        {
            var result = Zeile._4.IstErsteZeile();
            result.Should().BeFalse();
        }



    }
}