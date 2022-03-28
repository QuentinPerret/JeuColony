using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    abstract class FixedBatiment:Batiment
    {

        public FixedBatiment(int[] size, bool state, BaseMap M) : base(size, state,1, M)
        {

        }

    }
}
