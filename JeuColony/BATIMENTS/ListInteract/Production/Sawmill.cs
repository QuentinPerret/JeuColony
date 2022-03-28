using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract.Production
{
    class Sawmill : MainClass.ProductionBatiment
    {

        public Sawmill(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override int GenerateProduction(int level)
        {
            return level * 6;
        }
        public override String AfficheBatiment()
        {
            string chRes = "";
            chRes += " S " /*\n####"*/;
            return chRes;
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Sawmill S = new Sawmill(n, tab, b, p);
            return S;
        }
    }
}
