using System.Collections.Generic;
using System.Linq;

namespace KingdomEngine.Model
{
    public class Kingdom : IKingdom
    {
        private readonly ITreasury treasury;
        private readonly IEndTurnCalculator endTurnCalculator;
        
        public Kingdom(ITreasury treasury, IEndTurnCalculator endTurnCalculator)
        {
            this.treasury = treasury;
            this.endTurnCalculator = endTurnCalculator;
        }

        public int PeasantCount { get; private set; }
        public int KnightCount { get; private set; }
        public int ArcherCount { get; private set; }
        public int FoodCount { get; private set; }
        public int MarketplaceCount { get; private set; }
        public int FarmCount { get; private set; }
        public double TaxRate { get; set; }   
        public int Gold => treasury.Gold;
        public int Turn { get; set; }

        public void BuyFarm()
        {
            treasury.BuyFarm();
            FarmCount++;
        }

        public void BuyMarketplace()
        {
            treasury.BuyMarketplace();
            MarketplaceCount++;
        }

        public void TrainKnight()
        {
            treasury.TrainKnight();
            KnightCount++;
        }

        public int GetFarmCost()
        {
            return treasury.GetFarmCost();
        }

        public int GetKnightCost()
        {
            return treasury.GetKnightCost();
        }

        public int GetMarketplaceCost()
        {
            return treasury.GetMarketplaceCost();
        }

        public void EndTurn()
        {
            endTurnCalculator.
            var endTurnPackage = new EndTurnPackage { ArcherCount = ArcherCount, FarmCount = FarmCount, KnightCount = KnightCount };
            var turnResults = endTurnCalculator

            PeasantCount += turnResults.PeasantsGained;
            PeasantCount -= turnResults.PeasantsLost;
            FoodCount += turnResults.FoodProduced;

            turnResultsList.Add(turnResults);

            Turn++;
        }
    }
}
