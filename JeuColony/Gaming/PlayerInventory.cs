﻿using System;
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
        public PlayerInventory() { NbStone = 1; NbWood = 1; }
        public override string ToString()
        {
            string chRes = "\n";
            chRes += "Number of wood : " + NbWood + "\n";
            chRes += "Number of stone : " + NbStone + "\n";
            return chRes;
        }
    }
}
