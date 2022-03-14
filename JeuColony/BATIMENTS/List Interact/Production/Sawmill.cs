using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.ListInteract.Production
{
    class Sawmill : MainClass.ProductionBatiment
    {

        public Sawmill(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
        protected override int GenerateProduction(int level)
        {
            return level * 4;
        }
    {
    }
}
