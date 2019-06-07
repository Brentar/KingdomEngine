using System;

namespace KingdomEngine.Logic
{
    public interface IRandomizer
    {
        int GetRandomInteger(int from, int to);
    }

    public class Randomizer : IRandomizer
    {
        private readonly Random random;

        public Randomizer()
        {
            random = new Random();
        }

        public int GetRandomInteger(int from, int to)
        { 
            return random.Next(from, to + 1);
        }

        private int GetRandomizedAmount(int amount)
        {
            int plusOrMinusAmount = Convert.ToInt32(amount * RandomizationMultiplier);
            int minRange = amount - plusOrMinusAmount;
            int maxRange = amount + plusOrMinusAmount;
            return random.Next(minRange, maxRange);
        }

        //public int GetRandomR
    }
}
