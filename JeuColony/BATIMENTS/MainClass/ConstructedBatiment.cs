using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.MainClass
{
    class ConstructedBatiment:FixedBatiment
    {
        protected int ConstructorsNeeded { get; set;}
        protected bool _ready;
        protected int _length;
        protected int _lenghtMax;
        protected int _duration;
        public ConstructedBatiment(double[] size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
        protected abstract void Construct();
        protected Builder()
        {

        }
    }
}
