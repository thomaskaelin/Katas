using System.Collections.Generic;
using FakeItEasy;
using KataYatzy.Contracts;

namespace KataYatzy.Shared.Test.Helper
{
    public static class FakeCreator
    {
        public static IToss CreateFakeToss(IEnumerable<int> diceValues)
        {
            var fakeDices = new List<IDice>();

            foreach (var diceValue in diceValues)
            {
                var fakeDice = A.Fake<IDice>();
                A.CallTo(() => fakeDice.Value).Returns(diceValue);

                fakeDices.Add(fakeDice);
            }

            var fakeToss = A.Fake<IToss>();
            A.CallTo(() => fakeToss.Dices).Returns(fakeDices);

            return fakeToss;
        }
    }
}
