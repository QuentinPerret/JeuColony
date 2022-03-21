using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListFixed.ListConstructed
{
    class Road:ConstructedBatiment
    {
        public Road(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state)
        {
            _ready=false;
            _length=0;
            _lengthMax=30;

        }
        protected override void Construct(/*List<Builder> Builders,length*/)
        {
            
        }
        protected override void GenerateStat()
        {
            Health = HealthMax * 4 * Level;
        }
        protected override Batiment GenerateBatiment(int n, int[] tab, bool b, int p)
        {
            Road R = new Road(n, tab, b, p);
            return R;
        }
    }
}
