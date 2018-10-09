using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopKingdom.Model
{
    public abstract class Land
    {
        public int MaintenanceCost { get; set; }
        public int PeasantCapacity { get; set; }
        public int Cost { get; set; }
    }
}
