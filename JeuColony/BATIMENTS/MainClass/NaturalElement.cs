using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.Abstract_Class
{
    class NaturalElement:FixedBatiment
    {
        protected int Health { get; set;}
        public NaturalElement(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
        protected abstract void Remove();
    }
}
