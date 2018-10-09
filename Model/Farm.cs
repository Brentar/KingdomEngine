namespace DesktopKingdom.Model
{
    public class Farm : Land
    {
        public Farm(int production, int startingFood)
        {
            Production = production;
            Food = startingFood;
        }

        public int Production { get; set; }

        public int Food { get; private set; }

        public void ProduceFood()
        {
            Food += Production;
        }
    }
}
