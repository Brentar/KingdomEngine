using KingdomEngine.Logic;
using KingdomEngine.Model;
using NUnit.Framework;

namespace KingdomEngineTests
{
    [TestFixture]
    public class TreasuryTests
    {
        private const uint BaseFarmCost = 100;

        [SetUp]
        public void SetUp()
        {
            var costCalculator = new CostCalculator(new CostCalculatorSettings());
            var treasury = new Treasury(costCalculator);
            var x = 0;
        }

        [TestCase(100u)]
        [TestCase(0u)]
        public void AddGold(uint gold)
        {
            var costCalculator = new CostCalculator(new CostCalculatorSettings());
            var treasury = new Treasury(costCalculator);

            treasury.AddGold(gold);

            Assert.That(treasury.Gold, Is.EqualTo(gold));
        }

        [TestCase(100u, 50u)]
        public void BuyFarm(uint baseFarmCost, uint expectedGold)
        {
            var costCalculator = new CostCalculator(new CostCalculatorSettings { BaseFarmCost = baseFarmCost });
            var treasury = new Treasury(costCalculator);

            treasury.BuyFarm();

            Assert.That(treasury.Gold, Is.EqualTo(expectedGold));
        }
    }
}
