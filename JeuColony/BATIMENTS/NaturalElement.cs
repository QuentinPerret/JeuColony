using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    abstract class NaturalElement:Batiment
    {
        public NaturalElement(int[] size, int[] coordinate, bool state, BaseMap Map) : base(size, coordinate, state, Map) { }
        public NaturalElement(int[] size, bool state, BaseMap M) : base(size, state, M){ }
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }

    }
}
