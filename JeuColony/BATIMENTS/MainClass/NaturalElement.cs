using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS
{
    abstract class NaturalElement:FixedBatiment
    {
        public NaturalElement(double[] size, int[] coordinate, bool state) : base(size, coordinate, state)
        {

        }
        protected abstract void Remove();
        protected override void GenerateStat()
        {
            Health = HealthMax * 5 * Level;
        }
    }
}
