using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS
{
    abstract class FixedBatiment:Batiment
    {
        public FixedBatiment(double[] size, int[] coordinate, bool state) : base(size, coordinate, state, 1)
        {

        }
    }
}
