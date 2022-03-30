using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony
{
    class PlayerInventory
    {
        public int NbWood { get; set; }
        public int NbStone { get; set; }
        public PlayerInventory() { NbStone = 0; NbWood = 0; }
    }
}
