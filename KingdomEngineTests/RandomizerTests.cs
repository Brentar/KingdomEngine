using KingdomEngine.Logic;
using NUnit.Framework;

namespace KingdomEngineTests
{
    [TestFixture]
    public class RandomizerTests
    {
        private IRandomizer randomizer;

        [SetUp]
        public void SetUp()
        {
            randomizer = new Randomizer(.1);
        }

        [TestCase(10, 9, 11)]
        [TestCase(100, 90, 110)]
        public void TestMethod1(int amount, int from, int to)
        {
            int randomizedAmount = randomizer.GetRandomizedAmount(amount);

            Assert.That(randomizedAmount, Is.InRange(from, to));
        }
    }
}
