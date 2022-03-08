using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.MainClass
{
    abstract class DefenseBatiment:InteractiveBatiment
    {
        public DefenseBatiment(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
        protected abstract int GenerateProtection(int level);
    }
}
