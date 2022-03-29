using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    class Mountain:NaturalElement
    {
        public Mountain(int[] size, int[] coordinate, bool state, BaseMap Map) : base(size, coordinate, state, Map) { }
        public Mountain(int[] size, bool state, BaseMap M) : base(size, state, M){ }
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
