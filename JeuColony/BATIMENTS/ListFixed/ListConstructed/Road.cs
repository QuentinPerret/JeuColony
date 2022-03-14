using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.BATIMENTS.ListFixed.ListConstructed
{
    class Road:FixedBatiment
    {
        public Road(double[] size, int[] coordinate, bool state) : base(size, coordinate, state)
        {
            _ready=false;
            _length=0;
            _lengthMax=30;

        }
        private override void Construct(List<Builder> Builders,length)
        {
            _duration = Bui
            
            Builders.occupied= false;
        }
    }
}
