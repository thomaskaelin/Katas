using System;
using FluentAssertions;
using NUnit.Framework;

namespace Chess_Kata.Test
{
    [TestFixture]
    public class SpalteExtensionsTest
    {

        [Test]
        public void Erhoehen_SpalteC_LiefertSpalteD()
        {
            var result = Spalte.C.Erhoehen();
            result.Should().Be(Spalte.D);
        }

        [Test]
        public void Erhöhen_SpalteH_LieferException()
        {
            Action action = () => { Spalte.H.Erhoehen(); };
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void Verringern_SpalteD_LiefertSpalteC()
        {
            var result = Spalte.D.Verringern();
            result.Should().Be(Spalte.C);
        }

        [Test]
        public void Verringern_SpalteA_LiefertException()
        {
            Action action = () => { Spalte.A.Verringern(); };
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void IstLetzteSpalte_SpalteH_LiefertTrue()
        {
            var result = Spalte.H.IstLetzteSpalte();
            result.Should().BeTrue();
        }

        [Test]
        public void IstLetzteSpalte_SpalteD_LiefertFalse()
        {
            var result = Spalte.D.IstLetzteSpalte();
            result.Should().BeFalse();
        }

        [Test]
        public void IstErsteSpalte_SpalteA_LiefertTrue()
        {
            var result = Spalte.A.IstErsteSpalte();
            result.Should().BeTrue();
        }

        [Test]
        public void IstErsteSpalte_SpalteD_LiefertFalse()
        {
            var result = Spalte.D.IstErsteSpalte();
            result.Should().BeFalse();
        }



    }
}