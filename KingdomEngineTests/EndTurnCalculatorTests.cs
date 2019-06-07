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
                TaxRate = 7
            };

            endTurnCalculator = new EndTurnCalculator(endTurnSettings);
        }

        [TestCase(100, 200)]
        [TestCase(0, 0)]
        public void EndTurn_FoodProduced(int farmCount, int expectedFoodProduced)
        {
            var endTurnPackage = new EndTurnPackage { FarmCount = farmCount };

            Mock<IRandomizer> r = new Mock<IRandomizer>();
            r.Setup(x => x.GetRandomInteger(180, 220)).Returns(189);

            endTurnCalculator.EndTurn(endTurnPackage);
            
            Assert.That(endTurnCalculator.FoodProduced, Is.EqualTo(expectedFoodProduced));
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
