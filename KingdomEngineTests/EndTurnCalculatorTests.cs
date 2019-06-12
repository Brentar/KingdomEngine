using KingdomEngine.Interfaces;
using KingdomEngine.Logic;
using KingdomEngine.Model;
using NUnit.Framework;
using Moq;

namespace KingdomEngineTests
{
    [TestFixture]
    public class EndTurnCalculatorTests
    {
        private EndTurnSettings endTurnSettings;
        private IEndTurnCalculator endTurnCalculator;

        [SetUp]
        public void SetUp()
        {
            endTurnSettings = new EndTurnSettings
            {
                FoodConsumptionRate = 1, 
                FoodProductionRate = 2, 
                PeasantGainPercentage = 5, 
                PeasantIncome = 7,
                PeasantsPerFarm = 5, 
                TaxRate = 7,
                RandomizationMultiplier = .1
            };

            endTurnCalculator = new EndTurnCalculator(endTurnSettings, new Randomizer(endTurnSettings.RandomizationMultiplier));
        }

        [TestCase(100, 180, 220)]
        [TestCase(0, 0, 0)]
        public void EndTurn_FoodProduced(int farmCount, int minRange, int maxRange)
        {
            var endTurnPackage = new EndTurnPackage { FarmCount = farmCount };
            endTurnCalculator.EndTurn(endTurnPackage);
            Assert.That(endTurnCalculator.FoodProduced, Is.InRange(minRange, maxRange));
        }

        [TestCase(100, 200, 212)]
        //[TestCase(0, 0)]
        public void EndTurn_FoodProduced2(int farmCount, int nonRandomAmount, int expectedAmount)
        {
            Mock<IRandomizer> r = new Mock<IRandomizer>();
            r.Setup(x => x.GetRandomizedAmount(nonRandomAmount)).Returns(expectedAmount);
            
            var endTurnPackage = new EndTurnPackage { FarmCount = farmCount };
            endTurnCalculator.EndTurn(endTurnPackage);
            
            Assert.That(endTurnCalculator.FoodProduced, Is.EqualTo(expectedAmount));
        }

        [TestCase(100, 100)]
        [TestCase(0, 0)]
        public void EndTurn_FoodConsumed(int peasantCount, int expectedFoodConsumed)
        {
            var endTurnPackage = new EndTurnPackage { PeasantCount = peasantCount };
            endTurnCalculator.EndTurn(endTurnPackage);
            Assert.That(endTurnCalculator.FoodConsumed, Is.EqualTo(expectedFoodConsumed));
        }

        [TestCase(99, 49)]
        [TestCase(0, 0)]
        public void EndTurn_TaxIncome(int peasantCount, int expectedTaxIncome)
        {
            var endTurnPackage = new EndTurnPackage { PeasantCount = peasantCount };
            endTurnCalculator.EndTurn(endTurnPackage);
            Assert.That(endTurnCalculator.TaxIncome, Is.EqualTo(expectedTaxIncome));
        }
    }
}
