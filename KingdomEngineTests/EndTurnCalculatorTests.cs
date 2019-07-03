using System;
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
        private Mock<IRandomizer> mockRandomizer;

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

            mockRandomizer = new Mock<IRandomizer>();
            endTurnCalculator = new EndTurnCalculator(endTurnSettings, mockRandomizer.Object);
        }

        [TestCase(100, 212)]
        [TestCase(0, 0)]
        public void EndTurn_FoodProduced(int farmCount, int expectedAmount)
        {
            int nonRandomAmount = Convert.ToInt32(farmCount * endTurnSettings.FoodProductionRate);
            mockRandomizer.Setup(x => x.GetRandomizedAmount(nonRandomAmount)).Returns(expectedAmount);
            
            var endTurnPackage = new EndTurnPackage { FarmCount = farmCount };
            endTurnCalculator.EndTurn(endTurnPackage);
            
            Assert.That(endTurnCalculator.FoodProduced, Is.EqualTo(expectedAmount));
        }

        [TestCase(100, 100)]
        [TestCase(0, 0)]
        public void EndTurn_FoodConsumed(int peasantCount, int expectedAmount)
        {
            int nonRandomAmount = Convert.ToInt32(peasantCount * endTurnSettings.FoodConsumptionRate);
            mockRandomizer.Setup(x => x.GetRandomizedAmount(nonRandomAmount)).Returns(expectedAmount);

            var endTurnPackage = new EndTurnPackage { PeasantCount = peasantCount };
            endTurnCalculator.EndTurn(endTurnPackage);

            Assert.That(endTurnCalculator.FoodConsumed, Is.EqualTo(expectedAmount));
        }

        [TestCase(99, 49)]
        [TestCase(0, 0)]
        public void EndTurn_TaxIncome(int peasantCount, int expectedTaxIncome)
        {
            var endTurnPackage = new EndTurnPackage { PeasantCount = peasantCount };
            endTurnCalculator.EndTurn(endTurnPackage);
            Assert.That(endTurnCalculator.TaxIncome, Is.EqualTo(expectedTaxIncome));
        }

        [TestCase()]
        public void EndTurn_PeasantsLost(int peasantCount, int foodCount, int expected)
        {
            var endTurnPackage = new EndTurnPackage { PeasantCount = peasantCount };
            endTurnCalculator.EndTurn(endTurnPackage);

            Assert.That(endTurnCalculator.PeasantsLost, Is.EqualTo(expected));
        }
    }
}
