using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdomEngine.Logic
{
    public interface IFoodConsumption
    {
        int FoodConsumed { get; }

        int ConsumptionRate { get; set; }
    }

    public class FoodConsumption
    {
        private IRandomizer randomizer;

        public FoodConsumption(IRandomizer randomizer)
        {
            this.randomizer = randomizer;
        }

        public int FoodConsumed { get; private set; }

        public void Consume(int personCount)
        {
            FoodConsumed = randomizer.GetRandomizedAmount(personCount * ConsumptionRate);
        }
    }
}
