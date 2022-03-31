using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    class Water:NaturalElement
    {
        public Water(int[] size, int[] coordinate, bool state, BaseMap Map) : base(size, coordinate, state, Map) { }
        public Water(int[] size, bool state, BaseMap M) : base(size, state, M){ }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " W " ;
            return chRes;
        }
    }
}
