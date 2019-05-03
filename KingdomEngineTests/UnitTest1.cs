using KingdomEngine;
using KingdomEngine.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KingdomEngineTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateKindgom()
        {
            var settings = new EndTurnSettings();
            var costCalculatorSettings = new CostCalculatorSettings(5, 100, 50, 100);
            var costCalculator = new CostCalculator(costCalculatorSettings);
            var treasury = new Treasury(costCalculator);
            var kingdom = new Kingdom(treasury);
        }
    }
}
