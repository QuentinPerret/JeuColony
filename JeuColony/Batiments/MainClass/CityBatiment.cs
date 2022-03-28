using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.MainClass
{
    abstract class CityBatiment:InteractiveBatiment
    {
        
        public CityBatiment(int[] size, bool state, BaseMap M) : base(size, state, M)
        {
        }
        protected abstract int GenerateCapaMax(int level);

    }
}
