using KingdomEngine.Interfaces;
using KingdomEngine.Logic;
using KingdomEngine.Model;
using Moq;
using NUnit.Framework;

namespace KingdomEngineTests
{
    [TestFixture]
    public class KingdomTests
    {
        private IKingdom kingdom;
        private const int Cost = 100;
        private Mock<IEndTurnCalculator> mockEndTurnCalculator;

        [SetUp]
        public void SetUp()
        {
            var treasury = new Treasury(100);
            var economySettings = new EconomySettings { BaseFarmCost = Cost, BaseMarketplaceCost = Cost, BaseKnightCost = Cost, BaseArcherCost = Cost };
            var economy = new Economy(economySettings);

            mockEndTurnCalculator = new Mock<IEndTurnCalculator>();
            kingdom = new Kingdom(treasury, mockEndTurnCalculator.Object, economy);
        }

        [Test]
        public void BuyFarm()
        {
            kingdom.BuyFarm();
            Assert.That(kingdom.FarmCount, Is.EqualTo(1));
        }

        [Test]
        public void BuyMarketplace()
        {
            kingdom.BuyMarketplace();
            Assert.That(kingdom.MarketplaceCount, Is.EqualTo(1));

        }

        [Test]
        public void TrainKnight()
        {
            kingdom.TrainKnight();
            Assert.That(kingdom.KnightCount, Is.EqualTo(1));
        }

        [Test]
        public void TrainArcher()
        {
            kingdom.TrainArcher();
            Assert.That(kingdom.ArcherCount, Is.EqualTo(1));
        }

        [Test]
        public void GetFarmCost()
        {
            Assert.That(kingdom.FarmCost, Is.EqualTo(Cost));
        }

        [Test]
        public void GetKnightCost()
        {
            Assert.That(kingdom.GetKnightCost(), Is.EqualTo(Cost));
        }

        [Test]
        public void GetArcherCost()
        {
            Assert.That(kingdom.ArcherCost, Is.EqualTo(Cost));
        }

        [Test]
        public void GetMarketplaceCost()
        {
            Assert.That(kingdom.MarketplaceCost, Is.EqualTo(Cost));
        }

        [TestCase(20, 5, 70, 9)]
        [TestCase(20, 5, 70, 9)]
        public void EndTurn(int peasantsGained, int peasantsLost, int foodProduced, int foodConsumed)
        {
            mockEndTurnCalculator.Setup(x => x.PeasantsGained).Returns(peasantsGained);
            mockEndTurnCalculator.Setup(x => x.PeasantsLost).Returns(peasantsLost);
            mockEndTurnCalculator.Setup(x => x.FoodProduced).Returns(foodProduced);
            mockEndTurnCalculator.Setup(x => x.FoodConsumed).Returns(foodConsumed);

            kingdom.EndTurn();

            Assert.That(kingdom.PeasantCount, Is.EqualTo(peasantsGained - peasantsLost));
            Assert.That(kingdom.FoodCount, Is.EqualTo(foodProduced - foodConsumed));
            Assert.That(kingdom.Turn, Is.EqualTo(2));
        }

        [Test]
        public void GetEndTurnResults(int peasantsGained)
        {
            var endTurnResults = kingdom.GetEndTurnResults();
        }
    }
}
