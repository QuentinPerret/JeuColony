using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    class Forest:NaturalElement
    {
        public Forest(int[] size, int[] coordinate, bool state, BaseMap Map) : base(size, coordinate, state, Map) { }
        public Forest(int[] size, bool state, BaseMap M) : base(size, state, M) { }
        public override string ToString()
        {
            string chRes = "";
            chRes += " F " /*\n####"*/;
            return chRes;
        }
    }
}
