using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract.Production
{
    class Smelter : MainClass.ProductionBatiment
    {

        public Smelter(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
        protected override int GenerateProduction(int level)
        {
            return level * 4;
        }
    }
}
