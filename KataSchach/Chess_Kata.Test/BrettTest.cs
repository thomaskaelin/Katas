using System;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal.Builders;

namespace Chess_Kata.Test
{
    [TestFixture]
    public class BrettTest
    {
        private Brett _target;

        [SetUp]
        public void SetUp()
        {
            _target = new Brett();
        }

        [Test]
        public void SetzeFigur_SetztFigurAnRichtigerPositionAufBrett()
        {
            var figur = A.Fake<IFigur>();
            var position = A.Fake<Position>();
            A.CallTo(() => position.Zeile).Returns(Zeile._1);
            A.CallTo(() => position.Spalte).Returns(Spalte.A);
            _target.SetzeFigur(position, figur);
            var result = _target.HoleFigur(position);
            result.Should().Be(figur);
        }

        [Test]
        public void HolePosition_MitVorhandenerFigur_LiefertRichtigePosition()
        {
            var figur = A.Fake<IFigur>();
            var position = A.Fake<Position>();
            A.CallTo(() => position.Zeile).Returns(Zeile._4);
            A.CallTo(() => position.Spalte).Returns(Spalte.G);
            _target.SetzeFigur(position, figur);
            var result = _target.HolePosition(figur);
            result.Zeile.Should().Be(position.Zeile);
            result.Spalte.Should().Be(position.Spalte);
        }

        [Test]
        public void HolePosition_MitNichtVorhandenerFigur_WirftException()
        {
            
            // Arrange
            Action act = () => {
                var figur = A.Fake<IFigur>();
                _target.HolePosition(figur);
            };

            // Act & Assert
            act.ShouldThrow<ArgumentException>();
        }
    }
}