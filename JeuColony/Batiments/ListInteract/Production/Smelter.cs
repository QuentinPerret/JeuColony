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
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override int GenerateProduction(int level)
        {
            return level * 4;
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Smelter S = new Smelter(n, tab, b, p);
            return S;
        }
    }
}
