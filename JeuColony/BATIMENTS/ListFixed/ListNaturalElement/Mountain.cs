using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListNaturalElement
{
    class Mountain:NaturalElement
    {
        public Mountain(int size, int[] coordinate, bool state) : base(size, coordinate, state)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }
        protected override void Remove()
        {

        }

        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Mountain M = new Mountain(n, tab, b);
            return M;
        }
        public override string AfficheBatiment()
        {
            string chRes = "";
            chRes += " M " /*\n####"*/;
            return chRes;
        }
    }
}
