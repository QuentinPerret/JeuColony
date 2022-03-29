using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListNaturalElement
{
    class Mountain:NaturalElement
    {
        public Mountain(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " M " /*\n####"*/;
            return chRes;
        }
    }
}
