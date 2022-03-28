using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract.Production
{
    class Farm:MainClass.ProductionBatiment
    {
        
        public Farm(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override int GenerateProduction(int level)
        {
            return level * 2;
        }
        public override String AfficheBatiment()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Farm F = new Farm(n, tab, b, p);
            return F;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " Ce batiment est une ferme, " + base.ToString() + ", elle produit " + Production + " de nourriture";
            return chRes;
        }
    }
}
