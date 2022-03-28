﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract.Production
{
    class Smelter : MainClass.ProductionBatiment
    {

        public Smelter(int[] size, bool state, int level, BaseMap M) : base(size, state, M)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override int GenerateProduction(int level)
        {
            return level * 4;
        }
    }
}
