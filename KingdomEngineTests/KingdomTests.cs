using System.Management.Instrumentation;
using KingdomEngine.Interfaces;
using KingdomEngine.Logic;
using KingdomEngine.Model;
using NUnit.Framework;

namespace KingdomEngineTests
{
    [TestFixture]
    public class KingdomTests
    {
        private IKingdom kingdom;
        private const int FarmCost = 100;

        [SetUp]
        public void SetUp()
        {
            var treasury = new Treasury(100);
            var endTurnCalculator = new EndTurnCalculator(new EndTurnSettings(), new Randomizer(0.1));
            var economySettings = new EconomySettings { BaseFarmCost = FarmCost };
            var economy = new Economy(economySettings);

            kingdom = new Kingdom(treasury, endTurnCalculator, economy);
        }

        [Test]
        public void BuyFarm()
        {
            kingdom.BuyFarm();

            Assert.That(kingdom.FarmCount, Is.EqualTo(1));
            Assert.That(kingdom.Gold, Is.Zero);
        }

        [Test]
        public void GetFarmCost()
        {
            int farmCost = kingdom.GetFarmCost();
            Assert.That(kingdom.FarmCost, Is.EqualTo(FarmCost));
        }
    }
}
