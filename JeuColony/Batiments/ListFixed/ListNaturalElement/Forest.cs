using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListNaturalElement
{
    class Forest:NaturalElement
    {
        public Forest(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
            //GenerateBatiment(size, coordinate, state, 1);
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
    }
}
