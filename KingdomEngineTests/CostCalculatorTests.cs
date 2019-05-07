using KingdomEngine.Logic;
using KingdomEngine.Model;
using NUnit.Framework;

namespace KingdomEngineTests
{
    [TestFixture]
    public class CostCalculatorTests
    {
        [Test]
        [TestCase(100, 110, 10)]
        [TestCase(107, 120, 12)]
        public void GetInflatedCosts(uint baseCost, uint expectedCost, uint inflationRate)
        {
            var costCalculatorSettings = new CostCalculatorSettings
            {
                BaseFarmCost = baseCost,
                BaseKnightCost = baseCost,
                BaseArcherCost = baseCost,
                InflationRate = inflationRate,
                BaseMarketplaceCost = baseCost
            };
            
            var costCalculator = new CostCalculator(costCalculatorSettings);

            costCalculator.InflateCosts();

            Assert.That(costCalculator.FarmCost, Is.EqualTo(expectedCost));
            Assert.That(costCalculator.MarketplaceCost, Is.EqualTo(expectedCost));
            Assert.That(costCalculator.KnightCost, Is.EqualTo(expectedCost));
            Assert.That(costCalculator.ArcherCost, Is.EqualTo(expectedCost));
        }

        [Test]
        [TestCase(10, 11, 12, 13)]
        public void SetInitialValues(uint baseFarmCost, uint baseMarketplaceCost, uint baseKnightCost, uint baseArcherCost)
        {
            var costCalculatorSettings = new CostCalculatorSettings
            {
                BaseFarmCost = baseFarmCost,
                BaseKnightCost = baseKnightCost,
                BaseArcherCost = baseArcherCost,
                BaseMarketplaceCost = baseMarketplaceCost
            };

            var costCalculator = new CostCalculator(costCalculatorSettings);

            Assert.That(costCalculator.FarmCost, Is.EqualTo(baseFarmCost));
            Assert.That(costCalculator.KnightCost, Is.EqualTo(baseKnightCost));
            Assert.That(costCalculator.MarketplaceCost, Is.EqualTo(baseMarketplaceCost));
            Assert.That(costCalculator.ArcherCost, Is.EqualTo(baseArcherCost));
        }
    }
}
