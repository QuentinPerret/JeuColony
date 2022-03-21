using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    abstract class ConstructedBatiment:FixedBatiment
    {
        protected int ConstructorsNeeded { get; set;}
        protected bool _ready;
        protected int _length;
        protected int _lengthMax;
        protected int _duration;
        public ConstructedBatiment(int size, int[] coordinate, bool state) : base(size, coordinate, state)
        {

        }
        protected abstract void Construct();

        
    }
}
