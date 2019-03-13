using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdomEngine.Model
{
    public class EndTurnPackage
    {
        public int KnightCount { get; set; }
        public int ArcherCount { get; set; }
        public int PeasantCount { get; set; }
        public int MarketplaceCount { get; set; }
        public int FarmCount { get; set; }
    }
}
