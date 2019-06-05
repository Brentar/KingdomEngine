using KingdomEngine.Interfaces;
using KingdomEngine.Logic;
using KingdomEngine.Model;
using NUnit.Framework;

namespace KingdomEngineTests
{
    [TestFixture]
    public class EconomyTests
    {
        private const int BaseFarmCost = 100,
            BaseKnightCost = 100,
            BaseArcherCost = 100,
            BaseMarketplaceCost = 100;

        private IEconomy economy;

        [SetUp]
        public void SetUp()
        {
            var costCalculatorSettings = new EconomySettings
            {
                BaseFarmCost = BaseFarmCost,
                BaseKnightCost = BaseKnightCost,
                BaseArcherCost = BaseArcherCost,
                BaseMarketplaceCost = BaseMarketplaceCost
            };

            economy = new Economy(costCalculatorSettings);
        }

        [TestCase(10, 110)]
        [TestCase(11, 111)]
        public void GetInflatedCosts(int inflationRate, int expectedCost)
        {
            economy.InflationRate = inflationRate;
            economy.InflateCosts();

            Assert.That(economy.FarmCost, Is.EqualTo(expectedCost));
            Assert.That(economy.MarketplaceCost, Is.EqualTo(expectedCost));
            Assert.That(economy.KnightCost, Is.EqualTo(expectedCost));
            Assert.That(economy.ArcherCost, Is.EqualTo(expectedCost));
        }

        [Test]
        public void SetInitialValues()
        {
            Assert.That(economy.FarmCost, Is.EqualTo(BaseFarmCost));
            Assert.That(economy.KnightCost, Is.EqualTo(BaseKnightCost));
            Assert.That(economy.MarketplaceCost, Is.EqualTo(BaseMarketplaceCost));
            Assert.That(economy.ArcherCost, Is.EqualTo(BaseArcherCost));
        }
    }
}
