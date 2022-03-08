using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.Main_Class
{
    class ConstructedBatiment:FixedBatiment
    {
        public ConstructedBatiment(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
    }
}
