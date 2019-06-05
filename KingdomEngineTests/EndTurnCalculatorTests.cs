using KingdomEngine.Interfaces;
using KingdomEngine.Logic;
using KingdomEngine.Model;
using NUnit.Framework;


namespace KingdomEngineTests
{
    [TestFixture]
    public class EndTurnCalculatorTests
    {
        [Test]
        public void EndTurn(int peasantCount, int foodCount, int expectedTaxIncome)
        {
            var endTurnSettings = new EndTurnSettings
            {
                FoodConsumptionRate = 1, FoodProductionRate = 2, PeasantGainPercentage = 5, PeasantIncome = 10,
                PeasantsPerFarm = 5, TaxRate = 7
            };

            var endTurnCalculator = new EndTurnCalculator(endTurnSettings);

            //var endTurnPackage

            //endTurnCalculator.EndTurn();

            Assert.That(endTurnCalculator.TaxIncome, Is.EqualTo(expectedTaxIncome));
        }
    }
}
