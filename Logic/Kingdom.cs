using KingdomEngine.Model;

namespace KingdomEngine.Logic
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
        public uint Gold => treasury.Gold;
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

        public void TrainArcher()
        {
            treasury.TrainArcher();
            ArcherCount++;
        }

        public uint GetFarmCost()
        {
            return treasury.GetFarmCost();
        }

        public uint GetKnightCost()
        {
            return treasury.GetKnightCost();
        }

        public uint GetMarketplaceCost()
        {
            return treasury.GetMarketplaceCost();
        }        

        public void EndTurn()
        {
            var endTurnPackage = GetEndTurnPackage();

            endTurnCalculator.EndTurn(endTurnPackage);

            PeasantCount += endTurnCalculator.PeasantsGained;
            PeasantCount -= endTurnCalculator.PeasantsLost;
            FoodCount += endTurnCalculator.FoodProduced;

            treasury.InflateCosts();

            Turn++;
        }

        private EndTurnPackage GetEndTurnPackage()
        {
            return new EndTurnPackage
            {
                FarmCount = FarmCount,
                PeasantCount = PeasantCount,
                FoodCount = FoodCount
            };
        }
    }
}
