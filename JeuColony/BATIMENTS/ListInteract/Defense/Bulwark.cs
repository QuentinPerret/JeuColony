using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract.Defense
{
    class Bulwark:MainClass.DefenseBatiment
    {
        protected int Protection { get; set; }
        public Bulwark(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
        protected override int GenerateProtection(int level)
        {
            return level * 5;
        }
        public override string AfficheBatiment()
        {
            string chRes = "";
            chRes += " B " /*\n####"*/;
            return chRes;
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Bulwark B = new Bulwark(n, tab, b, p);
            return B;
        }
    }
}
