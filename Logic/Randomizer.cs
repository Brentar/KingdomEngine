using System;

namespace KingdomEngine.Logic
{
    public interface IRandomizer
    {
        int GetRandomizedAmount(int amount);
    }
    public class Randomizer : IRandomizer
    {
        private readonly Random random;
        private readonly double randomizationMultiplier;

        public Randomizer(double randomizationMultiplier)
        {
            random = new Random();
            this.randomizationMultiplier = randomizationMultiplier;
        }

        public int GetRandomizedAmount(int amount)
        {
            int plusOrMinusAmount = Convert.ToInt32(amount * randomizationMultiplier);
            int minRange = amount - plusOrMinusAmount;
            int maxRange = amount + plusOrMinusAmount;
            return random.Next(minRange, maxRange);
        }
    }
}
