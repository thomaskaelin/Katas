﻿using NUnit.Framework;

namespace KataYatzy.Shared.Test
{
    [TestFixture]
    public class ScoreBoardFixture
    {
        private ScoreBoard _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new ScoreBoard();
        }
    }
}