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
            if (amount == 0) return 0;

            int plusOrMinusAmount = Convert.ToInt32(amount * randomizationMultiplier);
            int minRange = amount - plusOrMinusAmount;
            int maxRange = amount + plusOrMinusAmount;
            int randomizedAmount = random.Next(minRange, maxRange);

            return randomizedAmount < 1 ? 1 : randomizedAmount;
        }
    }
}
