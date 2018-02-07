using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using KataYatzy.Contracts;

namespace KataYatzy.Shared.Test.Helper
{
    public static class FakeCreator
    {
        public static IPlayer CreateFakePlayer(string name = "John Doe")
        {
            var fakePlayer = A.Fake<IPlayer>();

            A.CallTo(() => fakePlayer.Name).Returns(name);

            return fakePlayer;
        }

        public static ICombination CreateFakeCombination(CombinationType combinationType = CombinationType.Ones, int calculatedPoints = 0)
        {
            var fakePoints = CreateFakePoints(calculatedPoints);

            var fakeCombination = A.Fake<ICombination>();
            A.CallTo(() => fakeCombination.Type).Returns(combinationType);
            A.CallTo(() => fakeCombination.Calculate(A<IToss>.That.Not.IsNull())).Returns(fakePoints);

            return fakeCombination;
        }

        public static IToss CreateFakeToss()
        {
            return CreateFakeToss(Enumerable.Empty<int>());
        }

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

        public static IPoints CreateFakePoints(int points)
        {
            var fakePoints = A.Fake<IPoints>();

            A.CallTo(() => fakePoints.Value).Returns(points);

            return fakePoints;
        }
    }
}
