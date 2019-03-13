using System.Collections.Generic;
using System.Linq;

namespace KingdomEngine.Model
{
    public class Kingdom : IKingdom
    {
        private readonly IKingdomCalculator costCalculator;
        private readonly IBuyer buyer;
        private int peasantCount;
        private List<TurnResults> turnResultsList;

        public Kingdom(IKingdomCalculator calculator, IBuyer buyer, InitialValues initialValues)
        {
            this.costCalculator = calculator;
            this.buyer = buyer;
            turnResultsList = new List<TurnResults>();
            ArcherCount = initialValues.ArcherCount;
        }

        public int PeasantCount
        {
            get => peasantCount;
            private set => peasantCount = value < 0 ? 0 : value;
        }
        public int KnightCount { get; private set; }
        public int ArcherCount { get; private set; }
        public int FoodCount { get; private set; }
        public int MarketplaceCount { get; private set; }
        public int FarmCount { get; private set; }
        public double TaxRate { get; set; }   
        public int Gold => buyer.Gold;
        public int Turn => costCalculator.Turn;
        public TurnResults TurnResults => turnResultsList.Last();

        public void BuyFarm()
        {
            buyer.BuyFarm();
            FarmCount++;
        }

        public void BuyMarketplace()
        {
            buyer.BuyMarketplace();
            MarketplaceCount++;
        }

        public void TrainKnight()
        {
            buyer.TrainKnight();
            KnightCount++;
        }

        public void EndTurn()
        {
            var endTurnPackage = new EndTurnPackage { ArcherCount = ArcherCount, FarmCount = FarmCount, KnightCount = KnightCount };
            TurnResults turnResults = costCalculator.GetTurnResults(endTurnPackage);

            PeasantCount += turnResults.PeasantsGained;
            PeasantCount -= turnResults.PeasantsLost;

            turnResultsList.Add(turnResults);

            costCalculator.Turn++;
        }

        public int GetFarmCost()
        {
            return costCalculator.GetFarmCost();
        }

        public int GetKnightCost()
        {
            int knightCost = costCalculator.GetKnightCost();
            return knightCost;
        }

        public int GetMarketplaceCost()
        {
            int marketplaceCost = costCalculator.GetMarketplaceCost();
            return marketplaceCost;
        }
    }
}
